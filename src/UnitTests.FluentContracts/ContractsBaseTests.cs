using System;
using Ave.Extensions.FluentContracts;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts
{
    /// <summary>
    /// Concrete contract class for testing the base Contracts class.
    /// </summary>
    internal sealed class TestContracts : Contracts<string, TestContracts>
    {
        public TestContracts(string subject) : base(subject)
        {
        }

        public TestContracts BeNotEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !string.IsNullOrEmpty(s),
                TestContractCodes.NotEmpty,
                $"Expected non-empty string but found '{Subject}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        public TestContracts StartWithA(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.StartsWith("A"),
                TestContractCodes.StartWithA,
                $"Expected string starting with 'A' but found '{Subject}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }

    internal static class TestContractCodes
    {
        public static readonly ErrorCode _ = ContractCodes._ / "Test";
        public static readonly ErrorCode NotEmpty = _ / "NotEmpty";
        public static readonly ErrorCode StartWithA = _ / "StartWithA";
    }

    internal static class TestContractExtensions
    {
        public static TestContracts Should(this string subject) => new TestContracts(subject);
    }

    public class ContractsBaseTests
    {
        [Fact(DisplayName = "AB-001: Successful contract returns Result.IsSuccess with subject as value")]
        public void AB001()
        {
            // Arrange
            var subject = "Apple";

            // Act
            Result<string, Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Apple", result.Value);
        }

        [Fact(DisplayName = "AB-002: Failed contract returns Result.IsFailure with correct ErrorCode")]
        public void AB002()
        {
            // Arrange
            var subject = "Banana";

            // Act
            Result<string, Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TestContractCodes.StartWithA, result.Error.Code);
        }

        [Fact(DisplayName = "AB-003: Chaining with And works")]
        public void AB003()
        {
            // Arrange
            var subject = "Apple";

            // Act
            Result<string, Error> result = subject.Should().BeNotEmpty().And.StartWithA();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal("Apple", result.Value);
        }

        [Fact(DisplayName = "AB-004: Short-circuit: second contract skipped when first fails")]
        public void AB004()
        {
            // Arrange
            var subject = "";

            // Act
            Result<string, Error> result = subject.Should().BeNotEmpty().And.StartWithA();

            // Assert
            Assert.True(result.IsFailure);
            // Should have the first error code (NotEmpty), not StartWithA
            Assert.Equal(TestContractCodes.NotEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "AB-005: Error metadata is correctly attached")]
        public void AB005()
        {
            // Arrange
            var subject = "Banana";

            // Act
            Result<string, Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsFailure);
            Assert.NotNull(result.Error.Metadata);
            Assert.True(result.Error.Metadata!.ContainsKey("actual"));
            Assert.Equal("Banana", result.Error.Metadata["actual"]);
        }

        [Fact(DisplayName = "AB-006: Implicit conversion to Result works")]
        public void AB006()
        {
            // Arrange
            var subject = "Apple";

            // Act - implicit conversion
            Result<string, Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AB-007: Implicit conversion to VoidResult works")]
        public void AB007()
        {
            // Arrange
            var subject = "Apple";

            // Act - implicit conversion
            VoidResult<Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AB-008: Implicit conversion to VoidResult preserves error on failure")]
        public void AB008()
        {
            // Arrange
            var subject = "Banana";

            // Act - implicit conversion
            VoidResult<Error> result = subject.Should().StartWithA();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TestContractCodes.StartWithA, result.Error.Code);
        }

        [Fact(DisplayName = "AB-009: HasFailure returns false when no failure")]
        public void AB009()
        {
            // Arrange
            var subject = "Apple";

            // Act
            var contracts = subject.Should().StartWithA();

            // Assert
            Assert.False(contracts.HasFailure);
        }

        [Fact(DisplayName = "AB-010: HasFailure returns true when failure occurred")]
        public void AB010()
        {
            // Arrange
            var subject = "Banana";

            // Act
            var contracts = subject.Should().StartWithA();

            // Assert
            Assert.True(contracts.HasFailure);
        }

        [Fact(DisplayName = "AB-011: Subject property returns the original value")]
        public void AB011()
        {
            // Arrange
            var subject = "Test";

            // Act
            var contracts = subject.Should();

            // Assert
            Assert.Equal("Test", contracts.Subject);
        }

        [Fact(DisplayName = "AB-012: Because reason is included in error metadata")]
        public void AB012()
        {
            // Arrange
            var subject = "Banana";

            // Act
            Result<string, Error> result = subject.Should().StartWithA("because {0} requires it", "the spec");

            // Assert
            Assert.True(result.IsFailure);
            Assert.NotNull(result.Error.Metadata);
            Assert.True(result.Error.Metadata!.ContainsKey("reason"));
            Assert.Equal("because the spec requires it", result.Error.Metadata["reason"]);
        }
    }
}
