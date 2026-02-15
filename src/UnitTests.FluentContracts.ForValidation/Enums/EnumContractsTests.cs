using Ave.Extensions.FluentContracts;
using Ave.Extensions.FluentContracts.ForValidation;
using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.FluentContracts.ForValidation.Enums
{
    public class EnumContractsTests
    {
        private enum TestEnum
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 3
        }

        [Flags]
        private enum TestFlags
        {
            None = 0,
            Read = 1,
            Write = 2,
            Execute = 4,
            All = Read | Write | Execute
        }

        private enum OtherEnum
        {
            First = 1,
            Second = 2
        }

        #region Be / NotBe

        [Fact(DisplayName = "EN-001: Be succeeds when enum equals expected")]
        public void EN001()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Be(TestEnum.Second);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-002: Be fails when enum does not equal expected")]
        public void EN002()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Be(TestEnum.Second);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "EN-003: NotBe succeeds when enum does not equal unexpected")]
        public void EN003()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotBe(TestEnum.Second);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-004: NotBe fails when enum equals unexpected")]
        public void EN004()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotBe(TestEnum.Second);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeDefined / NotBeDefined

        [Fact(DisplayName = "EN-005: BeDefined succeeds when value is defined")]
        public void EN005()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().BeDefined();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-006: BeDefined fails when value is not defined")]
        public void EN006()
        {
            // Arrange
            var subject = (TestEnum)999;

            // Act
            Result<TestEnum?, Error> result = subject.Should().BeDefined();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.BeDefined, result.Error.Code);
        }

        [Fact(DisplayName = "EN-007: NotBeDefined succeeds when value is not defined")]
        public void EN007()
        {
            // Arrange
            var subject = (TestEnum)999;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotBeDefined();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-008: NotBeDefined fails when value is defined")]
        public void EN008()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotBeDefined();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.NotBeDefined, result.Error.Code);
        }

        #endregion

        #region HaveValue / NotHaveValue

        [Fact(DisplayName = "EN-009: HaveValue succeeds when value matches")]
        public void EN009()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveValue(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-010: HaveValue fails when value does not match")]
        public void EN010()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveValue(2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.HaveValue, result.Error.Code);
        }

        [Fact(DisplayName = "EN-011: NotHaveValue succeeds when value does not match")]
        public void EN011()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotHaveValue(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveSameValueAs / NotHaveSameValueAs

        [Fact(DisplayName = "EN-012: HaveSameValueAs succeeds when values match")]
        public void EN012()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveSameValueAs(OtherEnum.First);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-013: HaveSameValueAs fails when values differ")]
        public void EN013()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveSameValueAs(OtherEnum.Second);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.HaveSameValueAs, result.Error.Code);
        }

        [Fact(DisplayName = "EN-014: NotHaveSameValueAs succeeds when values differ")]
        public void EN014()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotHaveSameValueAs(OtherEnum.Second);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveSameNameAs / NotHaveSameNameAs

        [Fact(DisplayName = "EN-015: HaveSameNameAs succeeds when names match")]
        public void EN015()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveSameNameAs(OtherEnum.First);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-016: HaveSameNameAs fails when names differ")]
        public void EN016()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().HaveSameNameAs(OtherEnum.Second);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.HaveSameNameAs, result.Error.Code);
        }

        [Fact(DisplayName = "EN-017: NotHaveSameNameAs succeeds when names differ")]
        public void EN017()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().NotHaveSameNameAs(OtherEnum.Second);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region HaveFlag / NotHaveFlag

        [Fact(DisplayName = "EN-018: HaveFlag succeeds when flag is present")]
        public void EN018()
        {
            // Arrange
            var subject = TestFlags.Read | TestFlags.Write;

            // Act
            Result<TestFlags?, Error> result = subject.Should().HaveFlag(TestFlags.Read);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-019: HaveFlag fails when flag is not present")]
        public void EN019()
        {
            // Arrange
            var subject = TestFlags.Read;

            // Act
            Result<TestFlags?, Error> result = subject.Should().HaveFlag(TestFlags.Write);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.HaveFlag, result.Error.Code);
        }

        [Fact(DisplayName = "EN-020: NotHaveFlag succeeds when flag is not present")]
        public void EN020()
        {
            // Arrange
            var subject = TestFlags.Read;

            // Act
            Result<TestFlags?, Error> result = subject.Should().NotHaveFlag(TestFlags.Write);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-021: NotHaveFlag fails when flag is present")]
        public void EN021()
        {
            // Arrange
            var subject = TestFlags.Read | TestFlags.Write;

            // Act
            Result<TestFlags?, Error> result = subject.Should().NotHaveFlag(TestFlags.Read);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.NotHaveFlag, result.Error.Code);
        }

        #endregion

        #region Match

        [Fact(DisplayName = "EN-022: Match succeeds when predicate is satisfied")]
        public void EN022()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Match(e => e > TestEnum.First);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-023: Match fails when predicate is not satisfied")]
        public void EN023()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Match(e => e > TestEnum.First);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.Match, result.Error.Code);
        }

        [Fact(DisplayName = "EN-024: Match throws when predicate is null")]
        public void EN024()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => subject.Should().Match(null!));
        }

        #endregion

        #region BeOneOf

        [Fact(DisplayName = "EN-025: BeOneOf succeeds when value is in list")]
        public void EN025()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should().BeOneOf(TestEnum.First, TestEnum.Second, TestEnum.Third);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "EN-026: BeOneOf fails when value is not in list")]
        public void EN026()
        {
            // Arrange
            var subject = TestEnum.None;

            // Act
            Result<TestEnum?, Error> result = subject.Should().BeOneOf(TestEnum.First, TestEnum.Second, TestEnum.Third);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.BeOneOf, result.Error.Code);
        }

        [Fact(DisplayName = "EN-027: BeOneOf throws when validValues is null")]
        public void EN027()
        {
            // Arrange
            var subject = TestEnum.First;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => subject.Should().BeOneOf((TestEnum[])null!));
        }

        #endregion

        #region Nullable Enum

        [Fact(DisplayName = "EN-028: Be fails when nullable enum is null")]
        public void EN028()
        {
            // Arrange
            TestEnum? subject = null;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Be(TestEnum.First);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(EnumContractCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "EN-029: Be with nullable expected succeeds when both null")]
        public void EN029()
        {
            // Arrange
            TestEnum? subject = null;

            // Act
            Result<TestEnum?, Error> result = subject.Should().Be((TestEnum?)null);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "EN-030: Chaining multiple enum contracts works")]
        public void EN030()
        {
            // Arrange
            var subject = TestEnum.Second;

            // Act
            Result<TestEnum?, Error> result = subject.Should()
                .BeDefined()
                .And.Be(TestEnum.Second)
                .And.HaveValue(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
