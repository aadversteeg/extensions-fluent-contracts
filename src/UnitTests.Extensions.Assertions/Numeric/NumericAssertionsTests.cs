using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Numeric
{
    public class NumericAssertionsTests
    {
        #region Be / NotBe

        [Fact(DisplayName = "NA-001: Be succeeds when values are equal")]
        public void NA001()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().Be(42);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-002: Be fails when values are not equal")]
        public void NA002()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().Be(43);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "NA-003: NotBe succeeds when values are not equal")]
        public void NA003()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().NotBe(43);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-004: NotBe fails when values are equal")]
        public void NA004()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().NotBe(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BePositive / BeNegative

        [Fact(DisplayName = "NA-005: BePositive succeeds for positive value")]
        public void NA005()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BePositive();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-006: BePositive fails for zero")]
        public void NA006()
        {
            // Arrange
            var subject = 0;

            // Act
            Result<int, Error> result = subject.Should().BePositive();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BePositive, result.Error.Code);
        }

        [Fact(DisplayName = "NA-007: BePositive fails for negative value")]
        public void NA007()
        {
            // Arrange
            var subject = -1;

            // Act
            Result<int, Error> result = subject.Should().BePositive();

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact(DisplayName = "NA-008: BeNegative succeeds for negative value")]
        public void NA008()
        {
            // Arrange
            var subject = -42;

            // Act
            Result<int, Error> result = subject.Should().BeNegative();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-009: BeNegative fails for zero")]
        public void NA009()
        {
            // Arrange
            var subject = 0;

            // Act
            Result<int, Error> result = subject.Should().BeNegative();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeNegative, result.Error.Code);
        }

        #endregion

        #region BeGreaterThan / BeGreaterThanOrEqualTo

        [Fact(DisplayName = "NA-010: BeGreaterThan succeeds when value is greater")]
        public void NA010()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BeGreaterThan(41);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-011: BeGreaterThan fails when value is equal")]
        public void NA011()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BeGreaterThan(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeGreaterThan, result.Error.Code);
        }

        [Fact(DisplayName = "NA-012: BeGreaterThanOrEqualTo succeeds when value is equal")]
        public void NA012()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BeGreaterThanOrEqualTo(42);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-013: BeGreaterThanOrEqualTo fails when value is less")]
        public void NA013()
        {
            // Arrange
            var subject = 41;

            // Act
            Result<int, Error> result = subject.Should().BeGreaterThanOrEqualTo(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeGreaterThanOrEqualTo, result.Error.Code);
        }

        #endregion

        #region BeLessThan / BeLessThanOrEqualTo

        [Fact(DisplayName = "NA-014: BeLessThan succeeds when value is less")]
        public void NA014()
        {
            // Arrange
            var subject = 41;

            // Act
            Result<int, Error> result = subject.Should().BeLessThan(42);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-015: BeLessThan fails when value is equal")]
        public void NA015()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BeLessThan(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeLessThan, result.Error.Code);
        }

        [Fact(DisplayName = "NA-016: BeLessThanOrEqualTo succeeds when value is equal")]
        public void NA016()
        {
            // Arrange
            var subject = 42;

            // Act
            Result<int, Error> result = subject.Should().BeLessThanOrEqualTo(42);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-017: BeLessThanOrEqualTo fails when value is greater")]
        public void NA017()
        {
            // Arrange
            var subject = 43;

            // Act
            Result<int, Error> result = subject.Should().BeLessThanOrEqualTo(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeLessThanOrEqualTo, result.Error.Code);
        }

        #endregion

        #region BeInRange / NotBeInRange

        [Fact(DisplayName = "NA-018: BeInRange succeeds when value is within range")]
        public void NA018()
        {
            // Arrange
            var subject = 5;

            // Act
            Result<int, Error> result = subject.Should().BeInRange(1, 10);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-019: BeInRange succeeds when value is at minimum")]
        public void NA019()
        {
            // Arrange
            var subject = 1;

            // Act
            Result<int, Error> result = subject.Should().BeInRange(1, 10);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-020: BeInRange fails when value is outside range")]
        public void NA020()
        {
            // Arrange
            var subject = 11;

            // Act
            Result<int, Error> result = subject.Should().BeInRange(1, 10);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeInRange, result.Error.Code);
        }

        [Fact(DisplayName = "NA-021: NotBeInRange succeeds when value is outside range")]
        public void NA021()
        {
            // Arrange
            var subject = 11;

            // Act
            Result<int, Error> result = subject.Should().NotBeInRange(1, 10);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-022: NotBeInRange fails when value is within range")]
        public void NA022()
        {
            // Arrange
            var subject = 5;

            // Act
            Result<int, Error> result = subject.Should().NotBeInRange(1, 10);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.NotBeInRange, result.Error.Code);
        }

        #endregion

        #region BeOneOf

        [Fact(DisplayName = "NA-023: BeOneOf succeeds when value is in list")]
        public void NA023()
        {
            // Arrange
            var subject = 2;

            // Act
            Result<int, Error> result = subject.Should().BeOneOf(1, 2, 3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-024: BeOneOf fails when value is not in list")]
        public void NA024()
        {
            // Arrange
            var subject = 4;

            // Act
            Result<int, Error> result = subject.Should().BeOneOf(1, 2, 3);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BeOneOf, result.Error.Code);
        }

        #endregion

        #region Match

        [Fact(DisplayName = "NA-025: Match succeeds when predicate is true")]
        public void NA025()
        {
            // Arrange
            var subject = 4;

            // Act
            Result<int, Error> result = subject.Should().Match(x => x % 2 == 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-026: Match fails when predicate is false")]
        public void NA026()
        {
            // Arrange
            var subject = 5;

            // Act
            Result<int, Error> result = subject.Should().Match(x => x % 2 == 0);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.Match, result.Error.Code);
        }

        #endregion

        #region Other numeric types

        [Fact(DisplayName = "NA-027: Double assertions work")]
        public void NA027()
        {
            // Arrange
            var subject = 3.14;

            // Act
            Result<double, Error> result = subject.Should().BeGreaterThan(3.0).And.BeLessThan(4.0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-028: Decimal assertions work")]
        public void NA028()
        {
            // Arrange
            var subject = 19.99m;

            // Act
            Result<decimal, Error> result = subject.Should().BeInRange(10m, 20m);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-029: Long assertions work")]
        public void NA029()
        {
            // Arrange
            var subject = 1_000_000_000L;

            // Act
            Result<long, Error> result = subject.Should().BePositive();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "NA-030: Chaining multiple numeric assertions works")]
        public void NA030()
        {
            // Arrange
            var subject = 50;

            // Act
            Result<int, Error> result = subject.Should()
                .BePositive()
                .And.BeGreaterThan(0)
                .And.BeLessThan(100)
                .And.BeInRange(1, 99);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "NA-031: Chaining short-circuits on first failure")]
        public void NA031()
        {
            // Arrange
            var subject = -5;

            // Act
            Result<int, Error> result = subject.Should()
                .BePositive() // fails here
                .And.BeGreaterThan(0) // should not run
                .And.BeLessThan(100);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(NumericAssertionCodes.BePositive, result.Error.Code);
        }

        #endregion
    }
}
