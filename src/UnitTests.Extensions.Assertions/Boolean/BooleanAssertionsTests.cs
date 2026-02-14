using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Boolean
{
    public class BooleanAssertionsTests
    {
        #region BeTrue / BeFalse

        [Fact(DisplayName = "BA-001: BeTrue succeeds when value is true")]
        public void BA001()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().BeTrue();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-002: BeTrue fails when value is false")]
        public void BA002()
        {
            // Arrange
            var subject = false;

            // Act
            Result<bool, Error> result = subject.Should().BeTrue();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(BooleanAssertionCodes.BeTrue, result.Error.Code);
        }

        [Fact(DisplayName = "BA-003: BeFalse succeeds when value is false")]
        public void BA003()
        {
            // Arrange
            var subject = false;

            // Act
            Result<bool, Error> result = subject.Should().BeFalse();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-004: BeFalse fails when value is true")]
        public void BA004()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().BeFalse();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(BooleanAssertionCodes.BeFalse, result.Error.Code);
        }

        #endregion

        #region Be / NotBe

        [Fact(DisplayName = "BA-005: Be succeeds when values match")]
        public void BA005()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().Be(true);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-006: Be fails when values do not match")]
        public void BA006()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().Be(false);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(BooleanAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "BA-007: NotBe succeeds when values do not match")]
        public void BA007()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().NotBe(false);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-008: NotBe fails when values match")]
        public void BA008()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().NotBe(true);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(BooleanAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region Imply

        [Fact(DisplayName = "BA-009: Imply succeeds when antecedent is false")]
        public void BA009()
        {
            // Arrange - false implies anything
            var subject = false;

            // Act
            Result<bool, Error> result = subject.Should().Imply(false);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-010: Imply succeeds when antecedent is true and consequent is true")]
        public void BA010()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().Imply(true);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "BA-011: Imply fails when antecedent is true and consequent is false")]
        public void BA011()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().Imply(false);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(BooleanAssertionCodes.Imply, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "BA-012: Chaining works")]
        public void BA012()
        {
            // Arrange
            var subject = true;

            // Act
            Result<bool, Error> result = subject.Should().BeTrue().And.Be(true).And.NotBe(false);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
