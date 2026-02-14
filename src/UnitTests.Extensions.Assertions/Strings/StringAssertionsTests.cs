using Ave.Extensions.Assertions.Strings;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Strings
{
    public class StringAssertionsTests
    {
        #region Be / NotBe

        [Fact(DisplayName = "SA-001: Be succeeds when strings are equal")]
        public void SA001()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().Be("hello");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-002: Be fails when strings are not equal")]
        public void SA002()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().Be("world");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "SA-003: NotBe succeeds when strings are not equal")]
        public void SA003()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotBe("world");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-004: NotBe fails when strings are equal")]
        public void SA004()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotBe("hello");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeEmpty / NotBeEmpty

        [Fact(DisplayName = "SA-005: BeEmpty succeeds when string is empty")]
        public void SA005()
        {
            // Arrange
            var subject = "";

            // Act
            Result<string?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-006: BeEmpty fails when string is not empty")]
        public void SA006()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.BeEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "SA-007: NotBeEmpty succeeds when string is not empty")]
        public void SA007()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-008: NotBeEmpty fails when string is empty")]
        public void SA008()
        {
            // Arrange
            var subject = "";

            // Act
            Result<string?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.NotBeEmpty, result.Error.Code);
        }

        #endregion

        #region BeNullOrEmpty / NotBeNullOrEmpty

        [Fact(DisplayName = "SA-009: BeNullOrEmpty succeeds when string is null")]
        public void SA009()
        {
            // Arrange
            string? subject = null;

            // Act
            Result<string?, Error> result = subject.Should().BeNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-010: BeNullOrEmpty succeeds when string is empty")]
        public void SA010()
        {
            // Arrange
            var subject = "";

            // Act
            Result<string?, Error> result = subject.Should().BeNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-011: BeNullOrEmpty fails when string has content")]
        public void SA011()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().BeNullOrEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.BeNullOrEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "SA-012: NotBeNullOrEmpty succeeds when string has content")]
        public void SA012()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotBeNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-013: NotBeNullOrEmpty fails when string is null")]
        public void SA013()
        {
            // Arrange
            string? subject = null;

            // Act
            Result<string?, Error> result = subject.Should().NotBeNullOrEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.NotBeNullOrEmpty, result.Error.Code);
        }

        #endregion

        #region BeNullOrWhiteSpace / NotBeNullOrWhiteSpace

        [Fact(DisplayName = "SA-014: BeNullOrWhiteSpace succeeds when string is whitespace")]
        public void SA014()
        {
            // Arrange
            var subject = "   ";

            // Act
            Result<string?, Error> result = subject.Should().BeNullOrWhiteSpace();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-015: NotBeNullOrWhiteSpace succeeds when string has non-whitespace")]
        public void SA015()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotBeNullOrWhiteSpace();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveLength

        [Fact(DisplayName = "SA-016: HaveLength succeeds when length matches")]
        public void SA016()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().HaveLength(5);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-017: HaveLength fails when length does not match")]
        public void SA017()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().HaveLength(10);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.HaveLength, result.Error.Code);
        }

        #endregion

        #region StartWith / NotStartWith

        [Fact(DisplayName = "SA-018: StartWith succeeds when string starts with expected")]
        public void SA018()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().StartWith("hello");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-019: StartWith fails when string does not start with expected")]
        public void SA019()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().StartWith("world");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.StartWith, result.Error.Code);
        }

        [Fact(DisplayName = "SA-020: NotStartWith succeeds when string does not start with unexpected")]
        public void SA020()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().NotStartWith("world");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region EndWith / NotEndWith

        [Fact(DisplayName = "SA-021: EndWith succeeds when string ends with expected")]
        public void SA021()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().EndWith("world");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-022: EndWith fails when string does not end with expected")]
        public void SA022()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().EndWith("hello");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.EndWith, result.Error.Code);
        }

        #endregion

        #region Contain / NotContain

        [Fact(DisplayName = "SA-023: Contain succeeds when string contains expected")]
        public void SA023()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().Contain("lo wo");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-024: Contain fails when string does not contain expected")]
        public void SA024()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().Contain("xyz");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.Contain, result.Error.Code);
        }

        [Fact(DisplayName = "SA-025: NotContain succeeds when string does not contain unexpected")]
        public void SA025()
        {
            // Arrange
            var subject = "hello world";

            // Act
            Result<string?, Error> result = subject.Should().NotContain("xyz");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region MatchRegex / NotMatchRegex

        [Fact(DisplayName = "SA-026: MatchRegex succeeds when string matches pattern")]
        public void SA026()
        {
            // Arrange
            var subject = "hello123";

            // Act
            Result<string?, Error> result = subject.Should().MatchRegex(@"^[a-z]+\d+$");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-027: MatchRegex fails when string does not match pattern")]
        public void SA027()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().MatchRegex(@"^\d+$");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.MatchRegex, result.Error.Code);
        }

        [Fact(DisplayName = "SA-028: NotMatchRegex succeeds when string does not match pattern")]
        public void SA028()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().NotMatchRegex(@"^\d+$");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeUpperCased / BeLowerCased

        [Fact(DisplayName = "SA-029: BeUpperCased succeeds when all characters are uppercase")]
        public void SA029()
        {
            // Arrange
            var subject = "HELLO";

            // Act
            Result<string?, Error> result = subject.Should().BeUpperCased();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-030: BeUpperCased fails when not all characters are uppercase")]
        public void SA030()
        {
            // Arrange
            var subject = "Hello";

            // Act
            Result<string?, Error> result = subject.Should().BeUpperCased();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.BeUpperCased, result.Error.Code);
        }

        [Fact(DisplayName = "SA-031: BeLowerCased succeeds when all characters are lowercase")]
        public void SA031()
        {
            // Arrange
            var subject = "hello";

            // Act
            Result<string?, Error> result = subject.Should().BeLowerCased();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-032: BeLowerCased fails when not all characters are lowercase")]
        public void SA032()
        {
            // Arrange
            var subject = "Hello";

            // Act
            Result<string?, Error> result = subject.Should().BeLowerCased();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.BeLowerCased, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "SA-033: Chaining multiple string assertions works")]
        public void SA033()
        {
            // Arrange
            var subject = "Hello World";

            // Act
            Result<string?, Error> result = subject.Should()
                .NotBeNullOrEmpty()
                .And.StartWith("Hello")
                .And.EndWith("World")
                .And.HaveLength(11);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SA-034: Chaining short-circuits on first failure")]
        public void SA034()
        {
            // Arrange
            var subject = "Hello World";

            // Act
            Result<string?, Error> result = subject.Should()
                .NotBeNullOrEmpty()
                .And.StartWith("Goodbye") // fails here
                .And.EndWith("World"); // should not run

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringAssertionCodes.StartWith, result.Error.Code);
        }

        #endregion
    }
}
