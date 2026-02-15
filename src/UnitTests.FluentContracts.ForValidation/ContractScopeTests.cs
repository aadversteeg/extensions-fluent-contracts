using System;
using Ave.Extensions.FluentContracts;
using Ave.Extensions.FluentContracts.ForValidation;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts.ForValidation
{
    /// <summary>
    /// Concrete contract class for testing ContractScope.
    /// </summary>
    internal sealed class TestContracts : Contracts<string, TestContracts>
    {
        public TestContracts(string subject) : base(subject)
        {
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
        public static readonly ErrorCode StartWithA = _ / "StartWithA";
    }

    internal static class TestContractExtensions
    {
        public static TestContracts Test(this string subject) => new TestContracts(subject);
    }

    public class ContractScopeTests
    {
        [Fact(DisplayName = "AS-001: All() with all passing returns success")]
        public void AS001()
        {
            // Arrange & Act
            var result = ContractScope.All(
                () => "Apple".Test().StartWithA(),
                () => "Apricot".Test().StartWithA(),
                () => "Avocado".Test().StartWithA()
            );

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AS-002: All() with one failure returns that error")]
        public void AS002()
        {
            // Arrange & Act
            var result = ContractScope.All(
                () => "Apple".Test().StartWithA(),
                () => "Banana".Test().StartWithA(),
                () => "Avocado".Test().StartWithA()
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Single(result.Error);
            Assert.Equal(TestContractCodes.StartWithA, result.Error[0].Code);
        }

        [Fact(DisplayName = "AS-003: All() with multiple failures returns all errors")]
        public void AS003()
        {
            // Arrange & Act
            var result = ContractScope.All(
                () => "Banana".Test().StartWithA(),
                () => "Cherry".Test().StartWithA(),
                () => "Date".Test().StartWithA()
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(3, result.Error.Count);
            Assert.All(result.Error, e => Assert.Equal(TestContractCodes.StartWithA, e.Code));
        }

        [Fact(DisplayName = "AS-004: All() with no contracts returns success")]
        public void AS004()
        {
            // Arrange & Act
            var result = ContractScope.All();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AS-005: All() evaluates all contracts regardless of failures")]
        public void AS005()
        {
            // Arrange
            var evaluationCount = 0;
            Func<VoidResult<Error>> trackingContract = () =>
            {
                evaluationCount++;
                return "Banana".Test().StartWithA();
            };

            // Act
            var result = ContractScope.All(
                trackingContract,
                trackingContract,
                trackingContract
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(3, evaluationCount);
            Assert.Equal(3, result.Error.Count);
        }

        [Fact(DisplayName = "AS-006: All() with mixed pass/fail returns only failures")]
        public void AS006()
        {
            // Arrange & Act
            var result = ContractScope.All(
                () => "Apple".Test().StartWithA(),   // pass
                () => "Banana".Test().StartWithA(),  // fail
                () => "Apricot".Test().StartWithA(), // pass
                () => "Cherry".Test().StartWithA()   // fail
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(2, result.Error.Count);
        }
    }
}
