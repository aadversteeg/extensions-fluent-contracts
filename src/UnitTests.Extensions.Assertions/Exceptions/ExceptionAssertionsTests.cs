using Ave.Extensions.Assertions;
using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Exceptions
{
    public class ExceptionAssertionsTests
    {
        #region Throw<TException>

        [Fact(DisplayName = "EX-001: Throw succeeds when expected exception is thrown")]
        public void EX001()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test message");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal("Test message", result.Value!.Message);
        }

        [Fact(DisplayName = "EX-002: Throw succeeds when derived exception is thrown")]
        public void EX002()
        {
            // Arrange
            Action action = () => throw new ArgumentNullException("param");

            // Act
            Result<ArgumentException?, Error> result = action.Should().Throw<ArgumentException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-003: Throw fails when no exception is thrown")]
        public void EX003()
        {
            // Arrange
            Action action = () => { };

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.Throw, result.Error.Code);
        }

        [Fact(DisplayName = "EX-004: Throw fails when different exception type is thrown")]
        public void EX004()
        {
            // Arrange
            Action action = () => throw new ArgumentException("wrong type");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.Throw, result.Error.Code);
        }

        #endregion

        #region ThrowExactly<TException>

        [Fact(DisplayName = "EX-005: ThrowExactly succeeds when exact exception type is thrown")]
        public void EX005()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test message");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().ThrowExactly<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
        }

        [Fact(DisplayName = "EX-006: ThrowExactly fails when derived exception type is thrown")]
        public void EX006()
        {
            // Arrange
            Action action = () => throw new ArgumentNullException("param");

            // Act
            Result<ArgumentException?, Error> result = action.Should().ThrowExactly<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.ThrowExactly, result.Error.Code);
        }

        [Fact(DisplayName = "EX-007: ThrowExactly fails when no exception is thrown")]
        public void EX007()
        {
            // Arrange
            Action action = () => { };

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().ThrowExactly<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.ThrowExactly, result.Error.Code);
        }

        #endregion

        #region NotThrow

        [Fact(DisplayName = "EX-008: NotThrow succeeds when no exception is thrown")]
        public void EX008()
        {
            // Arrange
            Action action = () => { };

            // Act
            Result<Action, Error> result = action.Should().NotThrow();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-009: NotThrow fails when exception is thrown")]
        public void EX009()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("oops");

            // Act
            Result<Action, Error> result = action.Should().NotThrow();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.NotThrow, result.Error.Code);
        }

        #endregion

        #region NotThrow<TException>

        [Fact(DisplayName = "EX-010: NotThrow<T> succeeds when no exception is thrown")]
        public void EX010()
        {
            // Arrange
            Action action = () => { };

            // Act
            Result<Action, Error> result = action.Should().NotThrow<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-011: NotThrow<T> succeeds when different exception type is thrown")]
        public void EX011()
        {
            // Arrange
            Action action = () => throw new ArgumentException("different");

            // Act
            Result<Action, Error> result = action.Should().NotThrow<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-012: NotThrow<T> fails when specified exception type is thrown")]
        public void EX012()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("oops");

            // Act
            Result<Action, Error> result = action.Should().NotThrow<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.NotThrow, result.Error.Code);
        }

        [Fact(DisplayName = "EX-013: NotThrow<T> fails when derived exception type is thrown")]
        public void EX013()
        {
            // Arrange
            Action action = () => throw new ArgumentNullException("param");

            // Act
            Result<Action, Error> result = action.Should().NotThrow<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.NotThrow, result.Error.Code);
        }

        #endregion

        #region WithMessage

        [Fact(DisplayName = "EX-014: WithMessage succeeds when message matches exactly")]
        public void EX014()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Expected message");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Expected message");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-015: WithMessage succeeds with wildcard pattern")]
        public void EX015()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("The value is invalid");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("*value*invalid*");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-016: WithMessage fails when message does not match")]
        public void EX016()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Actual message");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Expected message");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.WithMessage, result.Error.Code);
        }

        [Fact(DisplayName = "EX-017: WithMessage with ? wildcard matches single character")]
        public void EX017()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test1");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("Test?");

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region WithInnerException

        [Fact(DisplayName = "EX-018: WithInnerException succeeds when inner exception matches")]
        public void EX018()
        {
            // Arrange
            var inner = new ArgumentException("inner");
            Action action = () => throw new InvalidOperationException("outer", inner);

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-019: WithInnerException fails when no inner exception")]
        public void EX019()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("no inner");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.WithInnerException, result.Error.Code);
        }

        [Fact(DisplayName = "EX-020: WithInnerException fails when inner exception type differs")]
        public void EX020()
        {
            // Arrange
            var inner = new NullReferenceException("inner");
            Action action = () => throw new InvalidOperationException("outer", inner);

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithInnerException<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.WithInnerException, result.Error.Code);
        }

        [Fact(DisplayName = "EX-021: WithInnerException with Type parameter succeeds")]
        public void EX021()
        {
            // Arrange
            var inner = new ArgumentException("inner");
            Action action = () => throw new InvalidOperationException("outer", inner);

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithInnerException(typeof(ArgumentException));

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Where

        [Fact(DisplayName = "EX-022: Where succeeds when predicate returns true")]
        public void EX022()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test123");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .Where(e => e.Message.Contains("123"));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-023: Where fails when predicate returns false")]
        public void EX023()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test");

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .Where(e => e.Message.Contains("123"));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.Where, result.Error.Code);
        }

        #endregion

        #region Which

        [Fact(DisplayName = "EX-024: Which provides access to the exception")]
        public void EX024()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("Test message");

            // Act
            var exceptionAssertions = action.Should().Throw<InvalidOperationException>();
            var exception = exceptionAssertions.Which;

            // Assert
            Assert.NotNull(exception);
            Assert.Equal("Test message", exception!.Message);
        }

        #endregion

        #region Invoking

        [Fact(DisplayName = "EX-025: Invoking with Action creates testable action")]
        public void EX025()
        {
            // Arrange
            var obj = new TestSubject();

            // Act
            Result<InvalidOperationException?, Error> result = obj
                .Invoking(s => s.ThrowException())
                .Should()
                .Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-026: Invoking with Func creates testable action")]
        public void EX026()
        {
            // Arrange
            var obj = new TestSubject();

            // Act
            Result<InvalidOperationException?, Error> result = obj
                .Invoking(s => s.GetValueWithException())
                .Should()
                .Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-027: Invoking with non-throwing method succeeds with NotThrow")]
        public void EX027()
        {
            // Arrange
            var obj = new TestSubject();

            // Act
            Result<Action, Error> result = obj
                .Invoking(s => s.DoNothing())
                .Should()
                .NotThrow();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "EX-028: Chaining WithMessage and WithInnerException works")]
        public void EX028()
        {
            // Arrange
            var inner = new ArgumentException("inner");
            Action action = () => throw new InvalidOperationException("outer message", inner);

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("*outer*")
                .And.WithInnerException<ArgumentException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EX-029: Chaining fails on first failing assertion")]
        public void EX029()
        {
            // Arrange
            var inner = new ArgumentException("inner");
            Action action = () => throw new InvalidOperationException("outer message", inner);

            // Act
            Result<InvalidOperationException?, Error> result = action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("wrong*")
                .And.WithInnerException<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ExceptionAssertionCodes.WithMessage, result.Error.Code);
        }

        #endregion

        #region Edge Cases

        [Fact(DisplayName = "EX-030: Throw with null action handles gracefully")]
        public void EX030()
        {
            // Arrange
            Action action = null!;

            // Act
            Result<InvalidOperationException?, Error> result = action.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact(DisplayName = "EX-031: WithInnerException throws when Type parameter is null")]
        public void EX031()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("test");
            var assertions = action.Should().Throw<InvalidOperationException>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => assertions.WithInnerException(null!));
        }

        [Fact(DisplayName = "EX-032: Where throws when predicate is null")]
        public void EX032()
        {
            // Arrange
            Action action = () => throw new InvalidOperationException("test");
            var assertions = action.Should().Throw<InvalidOperationException>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => assertions.Where(null!));
        }

        #endregion

        #region Helper Classes

        private class TestSubject
        {
            public void ThrowException()
            {
                throw new InvalidOperationException("Test exception");
            }

            public int GetValueWithException()
            {
                throw new InvalidOperationException("Test exception from func");
            }

            public void DoNothing()
            {
                // Does nothing
            }
        }

        #endregion
    }
}
