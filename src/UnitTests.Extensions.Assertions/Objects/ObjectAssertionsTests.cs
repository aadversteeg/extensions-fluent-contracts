using Ave.Extensions.Assertions.Objects;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Objects
{
    public class ObjectAssertionsTests
    {
        #region BeNull / NotBeNull

        [Fact(DisplayName = "OA-001: BeNull succeeds when object is null")]
        public void OA001()
        {
            // Arrange
            object? subject = null;

            // Act
            Result<object?, Error> result = subject.Should().BeNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-002: BeNull fails when object is not null")]
        public void OA002()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().BeNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeNull, result.Error.Code);
        }

        [Fact(DisplayName = "OA-003: NotBeNull succeeds when object is not null")]
        public void OA003()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBeNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-004: NotBeNull fails when object is null")]
        public void OA004()
        {
            // Arrange
            object? subject = null;

            // Act
            Result<object?, Error> result = subject.Should().NotBeNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.NotBeNull, result.Error.Code);
        }

        #endregion

        #region Be / NotBe

        [Fact(DisplayName = "OA-005: Be succeeds when objects are equal")]
        public void OA005()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().Be("test");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-006: Be fails when objects are not equal")]
        public void OA006()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().Be("other");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.Be, result.Error.Code);
        }

        [Fact(DisplayName = "OA-007: NotBe succeeds when objects are not equal")]
        public void OA007()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBe("other");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-008: NotBe fails when objects are equal")]
        public void OA008()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBe("test");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.NotBe, result.Error.Code);
        }

        #endregion

        #region BeSameAs / NotBeSameAs

        [Fact(DisplayName = "OA-009: BeSameAs succeeds when references are the same")]
        public void OA009()
        {
            // Arrange
            var subject = new object();
            var same = subject;

            // Act
            Result<object?, Error> result = subject.Should().BeSameAs(same);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-010: BeSameAs fails when references are different")]
        public void OA010()
        {
            // Arrange
            var subject = new object();
            var different = new object();

            // Act
            Result<object?, Error> result = subject.Should().BeSameAs(different);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeSameAs, result.Error.Code);
        }

        [Fact(DisplayName = "OA-011: NotBeSameAs succeeds when references are different")]
        public void OA011()
        {
            // Arrange
            var subject = new object();
            var different = new object();

            // Act
            Result<object?, Error> result = subject.Should().NotBeSameAs(different);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-012: NotBeSameAs fails when references are the same")]
        public void OA012()
        {
            // Arrange
            var subject = new object();
            var same = subject;

            // Act
            Result<object?, Error> result = subject.Should().NotBeSameAs(same);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.NotBeSameAs, result.Error.Code);
        }

        #endregion

        #region BeOfType / NotBeOfType

        [Fact(DisplayName = "OA-013: BeOfType succeeds when type matches exactly")]
        public void OA013()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().BeOfType(typeof(string));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-014: BeOfType fails when type does not match")]
        public void OA014()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().BeOfType(typeof(int));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeOfType, result.Error.Code);
        }

        [Fact(DisplayName = "OA-015: BeOfType fails when subject is null")]
        public void OA015()
        {
            // Arrange
            object? subject = null;

            // Act
            Result<object?, Error> result = subject.Should().BeOfType(typeof(string));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeOfType, result.Error.Code);
        }

        [Fact(DisplayName = "OA-016: NotBeOfType succeeds when type does not match")]
        public void OA016()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBeOfType(typeof(int));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-017: NotBeOfType fails when type matches")]
        public void OA017()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBeOfType(typeof(string));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.NotBeOfType, result.Error.Code);
        }

        #endregion

        #region BeAssignableTo / NotBeAssignableTo

        [Fact(DisplayName = "OA-018: BeAssignableTo succeeds when type is assignable")]
        public void OA018()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().BeAssignableTo(typeof(object));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-019: BeAssignableTo fails when type is not assignable")]
        public void OA019()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().BeAssignableTo(typeof(int));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeAssignableTo, result.Error.Code);
        }

        [Fact(DisplayName = "OA-020: NotBeAssignableTo succeeds when type is not assignable")]
        public void OA020()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBeAssignableTo(typeof(int));

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-021: NotBeAssignableTo fails when type is assignable")]
        public void OA021()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().NotBeAssignableTo(typeof(object));

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.NotBeAssignableTo, result.Error.Code);
        }

        #endregion

        #region Match

        [Fact(DisplayName = "OA-022: Match succeeds when predicate returns true")]
        public void OA022()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().Match(s => s is string str && str.Length > 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-023: Match fails when predicate returns false")]
        public void OA023()
        {
            // Arrange
            object subject = "";

            // Act
            Result<object?, Error> result = subject.Should().Match(s => s is string str && str.Length > 0);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.Match, result.Error.Code);
        }

        #endregion

        #region Error Metadata

        [Fact(DisplayName = "OA-024: Error metadata contains expected and actual values")]
        public void OA024()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().Be("other");

            // Assert
            Assert.True(result.IsFailure);
            Assert.NotNull(result.Error.Metadata);
            Assert.True(result.Error.Metadata!.ContainsKey("expected"));
            Assert.True(result.Error.Metadata!.ContainsKey("actual"));
            Assert.Equal("other", result.Error.Metadata!["expected"]);
            Assert.Equal("test", result.Error.Metadata!["actual"]);
        }

        [Fact(DisplayName = "OA-025: Error metadata contains formatted reason")]
        public void OA025()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should().Be("other", "because {0} says so", "the spec");

            // Assert
            Assert.True(result.IsFailure);
            Assert.NotNull(result.Error.Metadata);
            Assert.True(result.Error.Metadata!.ContainsKey("reason"));
            Assert.Equal("because the spec says so", result.Error.Metadata!["reason"]);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "OA-026: Chaining multiple assertions works")]
        public void OA026()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should()
                .NotBeNull()
                .And.BeOfType(typeof(string))
                .And.NotBe("other");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "OA-027: Chaining short-circuits on first failure")]
        public void OA027()
        {
            // Arrange
            object subject = "test";

            // Act
            Result<object?, Error> result = subject.Should()
                .NotBeNull()
                .And.BeOfType(typeof(int)) // fails here
                .And.Be("test"); // should not run

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ObjectAssertionCodes.BeOfType, result.Error.Code);
        }

        #endregion
    }
}
