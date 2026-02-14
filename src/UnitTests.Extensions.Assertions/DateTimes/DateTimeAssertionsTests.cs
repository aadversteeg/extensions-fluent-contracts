using System;
using Ave.Extensions.Assertions.DateTimes;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.DateTimes
{
    public class DateTimeAssertionsTests
    {
        #region Be / NotBe

        [Fact(DisplayName = "DT-001: Be succeeds when DateTime equals expected")]
        public void DT001()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().Be(new DateTime(2024, 6, 15, 10, 30, 0));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-002: Be fails when DateTime does not equal expected")]
        public void DT002()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().Be(new DateTime(2024, 6, 15, 11, 30, 0));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "DT-003: NotBe succeeds when DateTime does not equal unexpected")]
        public void DT003()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBe(new DateTime(2024, 6, 15, 11, 30, 0));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-004: NotBe fails when DateTime equals unexpected")]
        public void DT004()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBe(new DateTime(2024, 6, 15, 10, 30, 0));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeCloseTo / NotBeCloseTo

        [Fact(DisplayName = "DT-005: BeCloseTo succeeds when within precision")]
        public void DT005()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 5);
            var nearbyTime = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeCloseTo(nearbyTime, TimeSpan.FromSeconds(10));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-006: BeCloseTo fails when outside precision")]
        public void DT006()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 15);
            var nearbyTime = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeCloseTo(nearbyTime, TimeSpan.FromSeconds(10));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeCloseTo, result.Error.Code);
        }

        [Fact(DisplayName = "DT-007: NotBeCloseTo succeeds when outside precision")]
        public void DT007()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 15);
            var distantTime = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBeCloseTo(distantTime, TimeSpan.FromSeconds(10));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-008: NotBeCloseTo fails when within precision")]
        public void DT008()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 5);
            var distantTime = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBeCloseTo(distantTime, TimeSpan.FromSeconds(10));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.NotBeCloseTo, result.Error.Code);
        }

        [Fact(DisplayName = "DT-009: BeCloseTo throws when precision is negative")]
        public void DT009()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                subject.Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(-1)));
        }

        #endregion

        #region BeBefore / BeOnOrBefore / BeAfter / BeOnOrAfter

        [Fact(DisplayName = "DT-010: BeBefore succeeds when subject is before expected")]
        public void DT010()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 14);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeBefore(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-011: BeBefore fails when subject is not before expected")]
        public void DT011()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var expected = new DateTime(2024, 6, 14);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeBefore(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeBefore, result.Error.Code);
        }

        [Fact(DisplayName = "DT-012: BeOnOrBefore succeeds when subject equals expected")]
        public void DT012()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeOnOrBefore(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-013: BeAfter succeeds when subject is after expected")]
        public void DT013()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 16);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeAfter(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-014: BeAfter fails when subject is not after expected")]
        public void DT014()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 14);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeAfter(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeAfter, result.Error.Code);
        }

        [Fact(DisplayName = "DT-015: BeOnOrAfter succeeds when subject equals expected")]
        public void DT015()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeOnOrAfter(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-016: NotBeBefore delegates to BeOnOrAfter")]
        public void DT016()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBeBefore(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-017: NotBeAfter delegates to BeOnOrBefore")]
        public void DT017()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var expected = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBeAfter(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveYear / HaveMonth / HaveDay

        [Fact(DisplayName = "DT-018: HaveYear succeeds when year matches")]
        public void DT018()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveYear(2024);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-019: HaveYear fails when year does not match")]
        public void DT019()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveYear(2025);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.HaveYear, result.Error.Code);
        }

        [Fact(DisplayName = "DT-020: NotHaveYear succeeds when year does not match")]
        public void DT020()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotHaveYear(2025);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-021: HaveMonth succeeds when month matches")]
        public void DT021()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveMonth(6);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-022: HaveDay succeeds when day matches")]
        public void DT022()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveDay(15);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveHour / HaveMinute / HaveSecond

        [Fact(DisplayName = "DT-023: HaveHour succeeds when hour matches")]
        public void DT023()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 14, 30, 45);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveHour(14);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-024: HaveMinute succeeds when minute matches")]
        public void DT024()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 14, 30, 45);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveMinute(30);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-025: HaveSecond succeeds when second matches")]
        public void DT025()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 14, 30, 45);

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveSecond(45);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-026: NotHaveHour succeeds when hour does not match")]
        public void DT026()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 14, 30, 45);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotHaveHour(15);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeSameDateAs / NotBeSameDateAs

        [Fact(DisplayName = "DT-027: BeSameDateAs succeeds when dates match")]
        public void DT027()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);
            var expected = new DateTime(2024, 6, 15, 18, 45, 30);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeSameDateAs(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-028: BeSameDateAs fails when dates do not match")]
        public void DT028()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 10, 30, 0);
            var expected = new DateTime(2024, 6, 16, 10, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeSameDateAs(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeSameDateAs, result.Error.Code);
        }

        [Fact(DisplayName = "DT-029: NotBeSameDateAs succeeds when dates do not match")]
        public void DT029()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var unexpected = new DateTime(2024, 6, 16);

            // Act
            Result<DateTime?, Error> result = subject.Should().NotBeSameDateAs(unexpected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeOneOf

        [Fact(DisplayName = "DT-030: BeOneOf succeeds when DateTime is in valid values")]
        public void DT030()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var valid1 = new DateTime(2024, 6, 14);
            var valid2 = new DateTime(2024, 6, 15);
            var valid3 = new DateTime(2024, 6, 16);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeOneOf(valid1, valid2, valid3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-031: BeOneOf fails when DateTime is not in valid values")]
        public void DT031()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15);
            var valid1 = new DateTime(2024, 6, 14);
            var valid2 = new DateTime(2024, 6, 16);

            // Act
            Result<DateTime?, Error> result = subject.Should().BeOneOf(valid1, valid2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeOneOf, result.Error.Code);
        }

        #endregion

        #region BeIn (DateTimeKind)

        [Fact(DisplayName = "DT-032: BeIn succeeds when DateTimeKind matches")]
        public void DT032()
        {
            // Arrange
            var subject = DateTime.UtcNow;

            // Act
            Result<DateTime?, Error> result = subject.Should().BeIn(DateTimeKind.Utc);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-033: BeIn fails when DateTimeKind does not match")]
        public void DT033()
        {
            // Arrange
            var subject = DateTime.UtcNow;

            // Act
            Result<DateTime?, Error> result = subject.Should().BeIn(DateTimeKind.Local);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.BeIn, result.Error.Code);
        }

        #endregion

        #region Nullable DateTime

        [Fact(DisplayName = "DT-034: Be with nullable DateTime succeeds when both null")]
        public void DT034()
        {
            // Arrange
            DateTime? subject = null;

            // Act
            Result<DateTime?, Error> result = subject.Should().Be((DateTime?)null);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DT-035: Be with nullable DateTime fails when subject is null")]
        public void DT035()
        {
            // Arrange
            DateTime? subject = null;

            // Act
            Result<DateTime?, Error> result = subject.Should().Be(new DateTime(2024, 6, 15));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "DT-036: HaveYear fails when DateTime is null")]
        public void DT036()
        {
            // Arrange
            DateTime? subject = null;

            // Act
            Result<DateTime?, Error> result = subject.Should().HaveYear(2024);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DateTimeAssertionCodes.HaveYear, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "DT-037: Chaining multiple DateTime assertions works")]
        public void DT037()
        {
            // Arrange
            var subject = new DateTime(2024, 6, 15, 14, 30, 0);

            // Act
            Result<DateTime?, Error> result = subject.Should()
                .HaveYear(2024)
                .And.HaveMonth(6)
                .And.HaveDay(15)
                .And.HaveHour(14);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
