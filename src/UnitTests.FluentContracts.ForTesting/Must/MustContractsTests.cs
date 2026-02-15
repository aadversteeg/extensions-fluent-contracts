using Ave.Extensions.FluentContracts.ForTesting;
using System;
using Xunit;
using Xunit.Sdk;

namespace UnitTests.FluentContracts.ForTesting.Must
{
    /// <summary>
    /// Tests for Must() contracts that throw on failure.
    /// When running under xUnit, Must() throws XunitException.
    /// </summary>
    public class MustContractsTests
    {
        #region String Contracts

        [Fact(DisplayName = "MUST-001: Must().Be() succeeds when strings are equal")]
        public void MUST001()
        {
            // Arrange
            var subject = "hello";

            // Act & Assert - should not throw
            subject.Must().Be("hello");
        }

        [Fact(DisplayName = "MUST-002: Must().Be() throws when strings are not equal")]
        public void MUST002()
        {
            // Arrange
            var subject = "hello";

            // Act & Assert
            var exception = Assert.Throws<XunitException>(() => subject.Must().Be("world"));
            Assert.Contains("Expected", exception.Message);
        }

        [Fact(DisplayName = "MUST-003: Must().NotBe() succeeds when strings are different")]
        public void MUST003()
        {
            // Arrange
            var subject = "hello";

            // Act & Assert - should not throw
            subject.Must().NotBe("world");
        }

        [Fact(DisplayName = "MUST-004: Must().NotBe() throws when strings are equal")]
        public void MUST004()
        {
            // Arrange
            var subject = "hello";

            // Act & Assert
            var exception = Assert.Throws<XunitException>(() => subject.Must().NotBe("hello"));
            Assert.Contains("Did not expect", exception.Message);
        }

        [Fact(DisplayName = "MUST-005: Must().NotBeNullOrEmpty() succeeds for non-empty string")]
        public void MUST005()
        {
            // Arrange
            var subject = "hello";

            // Act & Assert - should not throw
            subject.Must().NotBeNullOrEmpty();
        }

        [Fact(DisplayName = "MUST-006: Must().NotBeNullOrEmpty() throws for empty string")]
        public void MUST006()
        {
            // Arrange
            var subject = "";

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().NotBeNullOrEmpty());
        }

        #endregion

        #region Boolean Contracts

        [Fact(DisplayName = "MUST-010: Must().BeTrue() succeeds for true")]
        public void MUST010()
        {
            // Arrange
            var subject = true;

            // Act & Assert - should not throw
            subject.Must().BeTrue();
        }

        [Fact(DisplayName = "MUST-011: Must().BeTrue() throws for false")]
        public void MUST011()
        {
            // Arrange
            var subject = false;

            // Act & Assert
            var exception = Assert.Throws<XunitException>(() => subject.Must().BeTrue());
            Assert.Contains("Expected true", exception.Message);
        }

        [Fact(DisplayName = "MUST-012: Must().BeFalse() succeeds for false")]
        public void MUST012()
        {
            // Arrange
            var subject = false;

            // Act & Assert - should not throw
            subject.Must().BeFalse();
        }

        [Fact(DisplayName = "MUST-013: Must().BeFalse() throws for true")]
        public void MUST013()
        {
            // Arrange
            var subject = true;

            // Act & Assert
            var exception = Assert.Throws<XunitException>(() => subject.Must().BeFalse());
            Assert.Contains("Expected false", exception.Message);
        }

        #endregion

        #region Numeric Contracts

        [Fact(DisplayName = "MUST-020: Must().Be() succeeds when numbers are equal")]
        public void MUST020()
        {
            // Arrange
            var subject = 42;

            // Act & Assert - should not throw
            subject.Must().Be(42);
        }

        [Fact(DisplayName = "MUST-021: Must().Be() throws when numbers are not equal")]
        public void MUST021()
        {
            // Arrange
            var subject = 42;

            // Act & Assert
            var exception = Assert.Throws<XunitException>(() => subject.Must().Be(100));
            Assert.Contains("Expected", exception.Message);
        }

        [Fact(DisplayName = "MUST-022: Must().BePositive() succeeds for positive number")]
        public void MUST022()
        {
            // Arrange
            var subject = 42;

            // Act & Assert - should not throw
            subject.Must().BePositive();
        }

        [Fact(DisplayName = "MUST-023: Must().BePositive() throws for negative number")]
        public void MUST023()
        {
            // Arrange
            var subject = -5;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().BePositive());
        }

        [Fact(DisplayName = "MUST-024: Must().BeInRange() succeeds when in range")]
        public void MUST024()
        {
            // Arrange
            var subject = 50;

            // Act & Assert - should not throw
            subject.Must().BeInRange(1, 100);
        }

        [Fact(DisplayName = "MUST-025: Must().BeInRange() throws when out of range")]
        public void MUST025()
        {
            // Arrange
            var subject = 150;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().BeInRange(1, 100));
        }

        #endregion

        #region Object Contracts

        [Fact(DisplayName = "MUST-030: Must().NotBeNull() succeeds for non-null object")]
        public void MUST030()
        {
            // Arrange
            object subject = new object();

            // Act & Assert - should not throw
            subject.Must().NotBeNull();
        }

        [Fact(DisplayName = "MUST-031: Must().NotBeNull() throws for null object")]
        public void MUST031()
        {
            // Arrange
            object? subject = null;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().NotBeNull());
        }

        [Fact(DisplayName = "MUST-032: Must().BeOfType<T>() succeeds for correct type")]
        public void MUST032()
        {
            // Arrange
            object subject = "hello";

            // Act & Assert - should not throw
            subject.Must().BeOfType<string>();
        }

        [Fact(DisplayName = "MUST-033: Must().BeOfType<T>() throws for incorrect type")]
        public void MUST033()
        {
            // Arrange
            object subject = "hello";

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().BeOfType<int>());
        }

        #endregion

        #region Guid Contracts

        [Fact(DisplayName = "MUST-040: Must().NotBeEmpty() succeeds for non-empty GUID")]
        public void MUST040()
        {
            // Arrange
            var subject = Guid.NewGuid();

            // Act & Assert - should not throw
            subject.Must().NotBeEmpty();
        }

        [Fact(DisplayName = "MUST-041: Must().NotBeEmpty() throws for empty GUID")]
        public void MUST041()
        {
            // Arrange
            var subject = Guid.Empty;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().NotBeEmpty());
        }

        #endregion

        #region Collection Contracts

        [Fact(DisplayName = "MUST-050: Must().NotBeEmpty() succeeds for non-empty collection")]
        public void MUST050()
        {
            // Arrange
            var subject = new[] { 1, 2, 3 };

            // Act & Assert - should not throw
            subject.Must().NotBeEmpty();
        }

        [Fact(DisplayName = "MUST-051: Must().NotBeEmpty() throws for empty collection")]
        public void MUST051()
        {
            // Arrange
            var subject = Array.Empty<int>();

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().NotBeEmpty());
        }

        [Fact(DisplayName = "MUST-052: Must().Contain() succeeds when element exists")]
        public void MUST052()
        {
            // Arrange
            var subject = new[] { 1, 2, 3 };

            // Act & Assert - should not throw
            subject.Must().Contain(2);
        }

        [Fact(DisplayName = "MUST-053: Must().Contain() throws when element missing")]
        public void MUST053()
        {
            // Arrange
            var subject = new[] { 1, 2, 3 };

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().Contain(99));
        }

        #endregion

        #region Chaining Contracts

        [Fact(DisplayName = "MUST-060: Must() contracts can be chained with And")]
        public void MUST060()
        {
            // Arrange
            var subject = "hello world";

            // Act & Assert - should not throw, all contracts pass
            subject.Must()
                .NotBeNullOrEmpty()
                .And.StartWith("hello")
                .And.EndWith("world")
                .And.Contain(" ");
        }

        [Fact(DisplayName = "MUST-061: Must() chain throws on first failure")]
        public void MUST061()
        {
            // Arrange
            var subject = "hello world";

            // Act & Assert - throws on StartWith("goodbye")
            Assert.Throws<XunitException>(() =>
                subject.Must()
                    .NotBeNullOrEmpty()
                    .And.StartWith("goodbye")
                    .And.EndWith("world"));
        }

        #endregion

        #region Short-Circuit Behavior

        [Fact(DisplayName = "MUST-070: Must() short-circuits on first failure")]
        public void MUST070()
        {
            // Arrange
            var subject = "";

            // Act & Assert
            // The first contract (NotBeNullOrEmpty) should throw immediately
            // The second contract (StartWith) should never be evaluated
            var exception = Assert.Throws<XunitException>(() =>
                subject.Must()
                    .NotBeNullOrEmpty()
                    .And.StartWith("anything"));

            // Message should be about empty string, not about StartWith
            Assert.Contains("non-null and non-empty", exception.Message);
        }

        #endregion

        #region Nullable Contracts

        [Fact(DisplayName = "MUST-080: Must() works with nullable bool")]
        public void MUST080()
        {
            // Arrange
            bool? subject = true;

            // Act & Assert - should not throw
            subject.Must().HaveValue().And.BeTrue();
        }

        [Fact(DisplayName = "MUST-081: Must().HaveValue() throws for null")]
        public void MUST081()
        {
            // Arrange
            bool? subject = null;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().HaveValue());
        }

        [Fact(DisplayName = "MUST-082: Must() works with nullable int")]
        public void MUST082()
        {
            // Arrange
            int? subject = 42;

            // Act & Assert - should not throw
            subject.Must().HaveValue().And.Be(42);
        }

        [Fact(DisplayName = "MUST-083: Must().HaveValue() throws for null int")]
        public void MUST083()
        {
            // Arrange
            int? subject = null;

            // Act & Assert
            Assert.Throws<XunitException>(() => subject.Must().HaveValue());
        }

        #endregion
    }
}
