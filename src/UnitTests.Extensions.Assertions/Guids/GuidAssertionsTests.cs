using System;
using Ave.Extensions.Assertions.Guids;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Guids
{
    public class GuidAssertionsTests
    {
        #region BeEmpty / NotBeEmpty

        [Fact(DisplayName = "GU-001: BeEmpty succeeds when Guid is empty")]
        public void GU001()
        {
            // Arrange
            var subject = Guid.Empty;

            // Act
            Result<Guid, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-002: BeEmpty fails when Guid is not empty")]
        public void GU002()
        {
            // Arrange
            var subject = Guid.NewGuid();

            // Act
            Result<Guid, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.BeEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "GU-003: NotBeEmpty succeeds when Guid is not empty")]
        public void GU003()
        {
            // Arrange
            var subject = Guid.NewGuid();

            // Act
            Result<Guid, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-004: NotBeEmpty fails when Guid is empty")]
        public void GU004()
        {
            // Arrange
            var subject = Guid.Empty;

            // Act
            Result<Guid, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.NotBeEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "GU-005: NotBeEmpty fails when Guid is null")]
        public void GU005()
        {
            // Arrange
            Guid? subject = null;

            // Act
            Result<Guid?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.NotBeEmpty, result.Error.Code);
        }

        #endregion

        #region Be / NotBe with Guid

        [Fact(DisplayName = "GU-006: Be with Guid succeeds when equal")]
        public void GU006()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");
            var expected = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should().Be(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-007: Be with Guid fails when not equal")]
        public void GU007()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");
            var expected = new Guid("87654321-4321-4321-4321-210987654321");

            // Act
            Result<Guid, Error> result = subject.Should().Be(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "GU-008: NotBe with Guid succeeds when not equal")]
        public void GU008()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");
            var unexpected = new Guid("87654321-4321-4321-4321-210987654321");

            // Act
            Result<Guid, Error> result = subject.Should().NotBe(unexpected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-009: NotBe with Guid fails when equal")]
        public void GU009()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");
            var unexpected = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should().NotBe(unexpected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region Be / NotBe with string

        [Fact(DisplayName = "GU-010: Be with string succeeds when equal")]
        public void GU010()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should().Be("12345678-1234-1234-1234-123456789012");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-011: Be with string fails when not equal")]
        public void GU011()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should().Be("87654321-4321-4321-4321-210987654321");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "GU-012: Be with invalid string throws ArgumentException")]
        public void GU012()
        {
            // Arrange
            var subject = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => subject.Should().Be("not-a-guid"));
        }

        [Fact(DisplayName = "GU-013: NotBe with string succeeds when not equal")]
        public void GU013()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should().NotBe("87654321-4321-4321-4321-210987654321");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "GU-014: NotBe with invalid string throws ArgumentException")]
        public void GU014()
        {
            // Arrange
            var subject = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => subject.Should().NotBe("not-a-guid"));
        }

        #endregion

        #region Nullable Guid

        [Fact(DisplayName = "GU-015: Be fails when nullable Guid is null")]
        public void GU015()
        {
            // Arrange
            Guid? subject = null;
            var expected = Guid.NewGuid();

            // Act
            Result<Guid?, Error> result = subject.Should().Be(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "GU-016: BeEmpty fails when nullable Guid is null")]
        public void GU016()
        {
            // Arrange
            Guid? subject = null;

            // Act
            Result<Guid?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(GuidAssertionCodes.BeEmpty, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "GU-017: Chaining multiple Guid assertions works")]
        public void GU017()
        {
            // Arrange
            var subject = new Guid("12345678-1234-1234-1234-123456789012");

            // Act
            Result<Guid, Error> result = subject.Should()
                .NotBeEmpty()
                .And.Be("12345678-1234-1234-1234-123456789012");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
