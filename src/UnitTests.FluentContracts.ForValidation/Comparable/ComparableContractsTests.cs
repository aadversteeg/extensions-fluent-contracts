using Ave.Extensions.FluentContracts;
using Ave.Extensions.FluentContracts.ForValidation;
using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts.ForValidation.Comparable
{
    public class ComparableContractsTests
    {
        #region Be / NotBe

        [Fact(DisplayName = "CA-001: Be succeeds when values are equal")]
        public void CA001()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().Be(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-002: Be fails when values are not equal")]
        public void CA002()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().Be(new ComparableValue(43));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "CA-003: NotBe succeeds when values are not equal")]
        public void CA003()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().NotBe(new ComparableValue(43));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-004: NotBe fails when values are equal")]
        public void CA004()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().NotBe(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeRankedEquallyTo / NotBeRankedEquallyTo

        [Fact(DisplayName = "CA-005: BeRankedEquallyTo succeeds when CompareTo returns 0")]
        public void CA005()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeRankedEquallyTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-006: BeRankedEquallyTo fails when CompareTo returns non-zero")]
        public void CA006()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeRankedEquallyTo(new ComparableValue(43));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeRankedEquallyTo, result.Error.Code);
        }

        [Fact(DisplayName = "CA-007: NotBeRankedEquallyTo succeeds when CompareTo returns non-zero")]
        public void CA007()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().NotBeRankedEquallyTo(new ComparableValue(43));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-008: NotBeRankedEquallyTo fails when CompareTo returns 0")]
        public void CA008()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().NotBeRankedEquallyTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.NotBeRankedEquallyTo, result.Error.Code);
        }

        #endregion

        #region BeGreaterThan / BeGreaterThanOrEqualTo

        [Fact(DisplayName = "CA-009: BeGreaterThan succeeds when subject is greater")]
        public void CA009()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-010: BeGreaterThan fails when subject is equal")]
        public void CA010()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeGreaterThan, result.Error.Code);
        }

        [Fact(DisplayName = "CA-011: BeGreaterThan fails when subject is less")]
        public void CA011()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeGreaterThan, result.Error.Code);
        }

        [Fact(DisplayName = "CA-012: BeGreaterThanOrEqualTo succeeds when subject is greater")]
        public void CA012()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-013: BeGreaterThanOrEqualTo succeeds when subject is equal")]
        public void CA013()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-014: BeGreaterThanOrEqualTo fails when subject is less")]
        public void CA014()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeGreaterThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeGreaterThanOrEqualTo, result.Error.Code);
        }

        #endregion

        #region BeLessThan / BeLessThanOrEqualTo

        [Fact(DisplayName = "CA-015: BeLessThan succeeds when subject is less")]
        public void CA015()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-016: BeLessThan fails when subject is equal")]
        public void CA016()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeLessThan, result.Error.Code);
        }

        [Fact(DisplayName = "CA-017: BeLessThan fails when subject is greater")]
        public void CA017()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThan(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeLessThan, result.Error.Code);
        }

        [Fact(DisplayName = "CA-018: BeLessThanOrEqualTo succeeds when subject is less")]
        public void CA018()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-019: BeLessThanOrEqualTo succeeds when subject is equal")]
        public void CA019()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-020: BeLessThanOrEqualTo fails when subject is greater")]
        public void CA020()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable().BeLessThanOrEqualTo(new ComparableValue(42));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeLessThanOrEqualTo, result.Error.Code);
        }

        #endregion

        #region BeInRange / NotBeInRange

        [Fact(DisplayName = "CA-021: BeInRange succeeds when subject is within range")]
        public void CA021()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-022: BeInRange succeeds when subject is at minimum")]
        public void CA022()
        {
            // Arrange
            var subject = new ComparableValue(40);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-023: BeInRange succeeds when subject is at maximum")]
        public void CA023()
        {
            // Arrange
            var subject = new ComparableValue(60);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-024: BeInRange fails when subject is below range")]
        public void CA024()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeInRange, result.Error.Code);
        }

        [Fact(DisplayName = "CA-025: BeInRange fails when subject is above range")]
        public void CA025()
        {
            // Arrange
            var subject = new ComparableValue(70);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeInRange, result.Error.Code);
        }

        [Fact(DisplayName = "CA-026: NotBeInRange succeeds when subject is below range")]
        public void CA026()
        {
            // Arrange
            var subject = new ComparableValue(30);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .NotBeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-027: NotBeInRange succeeds when subject is above range")]
        public void CA027()
        {
            // Arrange
            var subject = new ComparableValue(70);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .NotBeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-028: NotBeInRange fails when subject is within range")]
        public void CA028()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .NotBeInRange(new ComparableValue(40), new ComparableValue(60));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.NotBeInRange, result.Error.Code);
        }

        #endregion

        #region BeOneOf

        [Fact(DisplayName = "CA-029: BeOneOf succeeds when subject matches one of the values")]
        public void CA029()
        {
            // Arrange
            var subject = new ComparableValue(42);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeOneOf(new ComparableValue(10), new ComparableValue(42), new ComparableValue(100));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-030: BeOneOf fails when subject doesn't match any value")]
        public void CA030()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeOneOf(new ComparableValue(10), new ComparableValue(42), new ComparableValue(100));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeOneOf, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "CA-031: Chained contracts all pass")]
        public void CA031()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeGreaterThan(new ComparableValue(40))
                .And.BeLessThan(new ComparableValue(60))
                .And.BeInRange(new ComparableValue(45), new ComparableValue(55));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-032: Chained contracts fail on second contract")]
        public void CA032()
        {
            // Arrange
            var subject = new ComparableValue(50);

            // Act
            Result<ComparableValue, Error> result = subject.ShouldBeComparable()
                .BeGreaterThan(new ComparableValue(40))
                .And.BeLessThan(new ComparableValue(45));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ComparableContractCodes.BeLessThan, result.Error.Code);
        }

        #endregion
    }

    /// <summary>
    /// A simple struct that implements IComparable{T} for testing purposes.
    /// </summary>
    public readonly struct ComparableValue : IComparable<ComparableValue>
    {
        public int Value { get; }

        public ComparableValue(int value)
        {
            Value = value;
        }

        public int CompareTo(ComparableValue other) => Value.CompareTo(other.Value);

        public override string ToString() => Value.ToString();
    }
}
