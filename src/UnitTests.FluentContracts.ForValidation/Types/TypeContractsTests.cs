using Ave.Extensions.FluentContracts;
using Ave.Extensions.FluentContracts.ForValidation;
using System;
using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts.ForValidation.Types
{
    public class TypeContractsTests
    {
        private interface ITestInterface { }

        private abstract class AbstractTestClass { }

        private sealed class SealedTestClass { }

        private class DerivedClass : AbstractTestClass, ITestInterface { }

        private class TestClassWithDefaultConstructor
        {
            public TestClassWithDefaultConstructor() { }
        }

        private class TestClassWithoutDefaultConstructor
        {
            public TestClassWithoutDefaultConstructor(int value) { }
        }

        [AttributeUsage(AttributeTargets.Class)]
        private class TestAttribute : Attribute { }

        [Test]
        private class DecoratedClass { }

        private class UndecoratedClass { }

        #region Be / NotBe

        [Fact(DisplayName = "TY-001: Be succeeds when types match")]
        public void TY001()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().Be(typeof(string));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-002: Be fails when types do not match")]
        public void TY002()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().Be(typeof(int));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "TY-003: Be<T> succeeds when types match")]
        public void TY003()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().Be<string>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-004: NotBe succeeds when types differ")]
        public void TY004()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().NotBe(typeof(int));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-005: NotBe fails when types match")]
        public void TY005()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().NotBe(typeof(string));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeAssignableTo / NotBeAssignableTo

        [Fact(DisplayName = "TY-006: BeAssignableTo succeeds for assignable type")]
        public void TY006()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeAssignableTo<AbstractTestClass>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-007: BeAssignableTo fails for non-assignable type")]
        public void TY007()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().BeAssignableTo<int>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeAssignableTo, result.Error.Code);
        }

        [Fact(DisplayName = "TY-008: NotBeAssignableTo succeeds for non-assignable type")]
        public void TY008()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeAssignableTo<int>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-009: BeAssignableTo throws when type is null")]
        public void TY009()
        {
            // Arrange
            var subject = typeof(string);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => subject.Should().BeAssignableTo(null!));
        }

        #endregion

        #region Implement / NotImplement

        [Fact(DisplayName = "TY-010: Implement succeeds when type implements interface")]
        public void TY010()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().Implement<ITestInterface>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-011: Implement fails when type does not implement interface")]
        public void TY011()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().Implement<ITestInterface>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.Implement, result.Error.Code);
        }

        [Fact(DisplayName = "TY-012: NotImplement succeeds when type does not implement interface")]
        public void TY012()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().NotImplement<ITestInterface>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-013: Implement throws when interfaceType is not an interface")]
        public void TY013()
        {
            // Arrange
            var subject = typeof(string);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => subject.Should().Implement(typeof(string)));
        }

        #endregion

        #region BeDerivedFrom / NotBeDerivedFrom

        [Fact(DisplayName = "TY-014: BeDerivedFrom succeeds when type is derived")]
        public void TY014()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeDerivedFrom<AbstractTestClass>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-015: BeDerivedFrom fails when type is not derived")]
        public void TY015()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().BeDerivedFrom<AbstractTestClass>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeDerivedFrom, result.Error.Code);
        }

        [Fact(DisplayName = "TY-016: NotBeDerivedFrom succeeds when type is not derived")]
        public void TY016()
        {
            // Arrange
            var subject = typeof(string);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeDerivedFrom<AbstractTestClass>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-017: BeDerivedFrom throws when baseType is an interface")]
        public void TY017()
        {
            // Arrange
            var subject = typeof(string);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => subject.Should().BeDerivedFrom(typeof(ITestInterface)));
        }

        #endregion

        #region BeSealed / NotBeSealed

        [Fact(DisplayName = "TY-018: BeSealed succeeds for sealed class")]
        public void TY018()
        {
            // Arrange
            var subject = typeof(SealedTestClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeSealed();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-019: BeSealed fails for non-sealed class")]
        public void TY019()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeSealed();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeSealed, result.Error.Code);
        }

        [Fact(DisplayName = "TY-020: NotBeSealed succeeds for non-sealed class")]
        public void TY020()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeSealed();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeAbstract / NotBeAbstract

        [Fact(DisplayName = "TY-021: BeAbstract succeeds for abstract class")]
        public void TY021()
        {
            // Arrange
            var subject = typeof(AbstractTestClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeAbstract();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-022: BeAbstract fails for non-abstract class")]
        public void TY022()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeAbstract();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeAbstract, result.Error.Code);
        }

        [Fact(DisplayName = "TY-023: NotBeAbstract succeeds for non-abstract class")]
        public void TY023()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeAbstract();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeInterface / NotBeInterface

        [Fact(DisplayName = "TY-024: BeInterface succeeds for interface")]
        public void TY024()
        {
            // Arrange
            var subject = typeof(ITestInterface);

            // Act
            Result<Type?, Error> result = subject.Should().BeInterface();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-025: BeInterface fails for class")]
        public void TY025()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeInterface();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeInterface, result.Error.Code);
        }

        [Fact(DisplayName = "TY-026: NotBeInterface succeeds for class")]
        public void TY026()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeInterface();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeClass / NotBeClass

        [Fact(DisplayName = "TY-027: BeClass succeeds for class")]
        public void TY027()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeClass();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-028: BeClass fails for interface")]
        public void TY028()
        {
            // Arrange
            var subject = typeof(ITestInterface);

            // Act
            Result<Type?, Error> result = subject.Should().BeClass();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeClass, result.Error.Code);
        }

        [Fact(DisplayName = "TY-029: NotBeClass succeeds for interface")]
        public void TY029()
        {
            // Arrange
            var subject = typeof(ITestInterface);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeClass();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region BeDecoratedWith / NotBeDecoratedWith

        [Fact(DisplayName = "TY-030: BeDecoratedWith succeeds when decorated")]
        public void TY030()
        {
            // Arrange
            var subject = typeof(DecoratedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeDecoratedWith<TestAttribute>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-031: BeDecoratedWith fails when not decorated")]
        public void TY031()
        {
            // Arrange
            var subject = typeof(UndecoratedClass);

            // Act
            Result<Type?, Error> result = subject.Should().BeDecoratedWith<TestAttribute>();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.BeDecoratedWith, result.Error.Code);
        }

        [Fact(DisplayName = "TY-032: NotBeDecoratedWith succeeds when not decorated")]
        public void TY032()
        {
            // Arrange
            var subject = typeof(UndecoratedClass);

            // Act
            Result<Type?, Error> result = subject.Should().NotBeDecoratedWith<TestAttribute>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveDefaultConstructor / NotHaveDefaultConstructor

        [Fact(DisplayName = "TY-033: HaveDefaultConstructor succeeds when exists")]
        public void TY033()
        {
            // Arrange
            var subject = typeof(TestClassWithDefaultConstructor);

            // Act
            Result<Type?, Error> result = subject.Should().HaveDefaultConstructor();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "TY-034: HaveDefaultConstructor fails when not exists")]
        public void TY034()
        {
            // Arrange
            var subject = typeof(TestClassWithoutDefaultConstructor);

            // Act
            Result<Type?, Error> result = subject.Should().HaveDefaultConstructor();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(TypeContractCodes.HaveDefaultConstructor, result.Error.Code);
        }

        [Fact(DisplayName = "TY-035: NotHaveDefaultConstructor succeeds when not exists")]
        public void TY035()
        {
            // Arrange
            var subject = typeof(TestClassWithoutDefaultConstructor);

            // Act
            Result<Type?, Error> result = subject.Should().NotHaveDefaultConstructor();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "TY-036: Chaining multiple type contracts works")]
        public void TY036()
        {
            // Arrange
            var subject = typeof(DerivedClass);

            // Act
            Result<Type?, Error> result = subject.Should()
                .BeClass()
                .And.NotBeSealed()
                .And.Implement<ITestInterface>()
                .And.BeDerivedFrom<AbstractTestClass>();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
