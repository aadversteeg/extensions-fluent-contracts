using Ave.Extensions.FluentContracts;
using Ave.Extensions.FluentContracts.ForValidation;
using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts.ForValidation.Functions
{
    public class FunctionContractsTests
    {
        #region Return / NotReturn

        [Fact(DisplayName = "FA-001: Return succeeds when function returns expected value")]
        public void FA001()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().Return(42);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-002: Return fails when function returns different value")]
        public void FA002()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().Return(99);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Return, result.Error.Code);
        }

        [Fact(DisplayName = "FA-003: Return fails when function throws")]
        public void FA003()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("test");

            // Act
            Result<Func<int>, Error> result = func.Should().Return(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Return, result.Error.Code);
        }

        [Fact(DisplayName = "FA-004: NotReturn succeeds when function returns different value")]
        public void FA004()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().NotReturn(99);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-005: NotReturn fails when function returns unexpected value")]
        public void FA005()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().NotReturn(42);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.NotReturn, result.Error.Code);
        }

        #endregion

        #region ReturnNotNull / ReturnNull

        [Fact(DisplayName = "FA-006: ReturnNotNull succeeds when function returns non-null")]
        public void FA006()
        {
            // Arrange
            Func<string> func = () => "hello";

            // Act
            Result<Func<string>, Error> result = func.Should().ReturnNotNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-007: ReturnNotNull fails when function returns null")]
        public void FA007()
        {
            // Arrange
            Func<string?> func = () => null;

            // Act
            Result<Func<string?>, Error> result = func.Should().ReturnNotNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.ReturnNotNull, result.Error.Code);
        }

        [Fact(DisplayName = "FA-008: ReturnNotNull fails when function throws")]
        public void FA008()
        {
            // Arrange
            Func<string> func = () => throw new InvalidOperationException("test");

            // Act
            Result<Func<string>, Error> result = func.Should().ReturnNotNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.ReturnNotNull, result.Error.Code);
        }

        [Fact(DisplayName = "FA-009: ReturnNull succeeds when function returns null")]
        public void FA009()
        {
            // Arrange
            Func<string?> func = () => null;

            // Act
            Result<Func<string?>, Error> result = func.Should().ReturnNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-010: ReturnNull fails when function returns non-null")]
        public void FA010()
        {
            // Arrange
            Func<string> func = () => "hello";

            // Act
            Result<Func<string>, Error> result = func.Should().ReturnNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.ReturnNull, result.Error.Code);
        }

        #endregion

        #region Satisfy

        [Fact(DisplayName = "FA-011: Satisfy succeeds when result satisfies predicate")]
        public void FA011()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().Satisfy(x => x > 40 && x < 50);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-012: Satisfy fails when result doesn't satisfy predicate")]
        public void FA012()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().Satisfy(x => x > 100);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Satisfy, result.Error.Code);
        }

        [Fact(DisplayName = "FA-013: Satisfy fails when function throws")]
        public void FA013()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("test");

            // Act
            Result<Func<int>, Error> result = func.Should().Satisfy(x => x > 0);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Satisfy, result.Error.Code);
        }

        #endregion

        #region NotThrow

        [Fact(DisplayName = "FA-014: NotThrow succeeds when function doesn't throw")]
        public void FA014()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should().NotThrow();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-015: NotThrow fails when function throws")]
        public void FA015()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("test");

            // Act
            Result<Func<int>, Error> result = func.Should().NotThrow();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.NotThrow, result.Error.Code);
        }

        [Fact(DisplayName = "FA-016: NotThrow<T> succeeds when function doesn't throw T")]
        public void FA016()
        {
            // Arrange
            Func<int> func = () => throw new ArgumentException("test");

            // Act
            Result<Func<int>, Error> result = func.Should().NotThrow<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-017: NotThrow<T> fails when function throws T")]
        public void FA017()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("test");

            // Act
            Result<Func<int>, Error> result = func.Should().NotThrow<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.NotThrow, result.Error.Code);
        }

        #endregion

        #region Throw

        [Fact(DisplayName = "FA-018: Throw succeeds when function throws expected exception")]
        public void FA018()
        {
            // Arrange
            Func<int> func = () => throw new InvalidOperationException("test");

            // Act
            Result<InvalidOperationException?, Error> result = func.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-019: Throw fails when function throws different exception")]
        public void FA019()
        {
            // Arrange
            Func<int> func = () => throw new ArgumentException("test");

            // Act
            Result<InvalidOperationException?, Error> result = func.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Throw, result.Error.Code);
        }

        [Fact(DisplayName = "FA-020: Throw fails when function doesn't throw")]
        public void FA020()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<InvalidOperationException?, Error> result = func.Should().Throw<InvalidOperationException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.Throw, result.Error.Code);
        }

        [Fact(DisplayName = "FA-021: Throw succeeds for derived exception type")]
        public void FA021()
        {
            // Arrange
            Func<int> func = () => throw new ArgumentNullException("param");

            // Act
            Result<ArgumentException?, Error> result = func.Should().Throw<ArgumentException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region ThrowExactly

        [Fact(DisplayName = "FA-022: ThrowExactly succeeds when function throws exact exception")]
        public void FA022()
        {
            // Arrange
            Func<int> func = () => throw new ArgumentException("test");

            // Act
            Result<ArgumentException?, Error> result = func.Should().ThrowExactly<ArgumentException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-023: ThrowExactly fails for derived exception type")]
        public void FA023()
        {
            // Arrange
            Func<int> func = () => throw new ArgumentNullException("param");

            // Act
            Result<ArgumentException?, Error> result = func.Should().ThrowExactly<ArgumentException>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(FunctionContractCodes.ThrowExactly, result.Error.Code);
        }

        #endregion

        #region Invoking

        [Fact(DisplayName = "FA-024: Function contract allows asserting on return value")]
        public void FA024()
        {
            // Arrange
            var subject = "hello world";
            Func<int> func = () => subject.Length;

            // Act
            Result<Func<int>, Error> result = func.Should().Return(11);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "FA-025: Invoking captures exceptions from method")]
        public void FA025()
        {
            // Arrange
            string? subject = null;

            // Act
            Result<NullReferenceException?, Error> result = subject.Invoking(s => s!.Length).Should().Throw<NullReferenceException>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "FA-026: Chaining function contracts works")]
        public void FA026()
        {
            // Arrange
            Func<int> func = () => 42;

            // Act
            Result<Func<int>, Error> result = func.Should()
                .NotThrow()
                .And.Return(42)
                .And.Satisfy(x => x > 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region GetResult

        [Fact(DisplayName = "FA-027: GetResult returns the function result")]
        public void FA027()
        {
            // Arrange
            Func<int> func = () => 42;
            var contracts = func.Should();

            // Act
            contracts.NotThrow();
            var value = contracts.GetResult();

            // Assert
            Assert.Equal(42, value);
        }

        #endregion
    }
}
