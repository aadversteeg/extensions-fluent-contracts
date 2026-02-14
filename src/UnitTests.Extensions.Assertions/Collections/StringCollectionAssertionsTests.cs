using System.Collections.Generic;
using Ave.Extensions.Assertions.Collections;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Collections
{
    public class StringCollectionAssertionsTests
    {
        #region ContainMatch / NotContainMatch

        [Fact(DisplayName = "SC-001: ContainMatch succeeds when pattern matches")]
        public void SC001()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().ContainMatch("^ban.*");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-002: ContainMatch fails when pattern doesn't match")]
        public void SC002()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().ContainMatch("^xyz.*");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.ContainMatch, result.Error.Code);
        }

        [Fact(DisplayName = "SC-003: NotContainMatch succeeds when pattern doesn't match")]
        public void SC003()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainMatch("^xyz.*");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-004: NotContainMatch fails when pattern matches")]
        public void SC004()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainMatch("^ban.*");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.NotContainMatch, result.Error.Code);
        }

        #endregion

        #region AllMatch

        [Fact(DisplayName = "SC-005: AllMatch succeeds when all items match pattern")]
        public void SC005()
        {
            // Arrange
            var subject = new List<string> { "test1", "test2", "test3" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().AllMatch("^test\\d$");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-006: AllMatch fails when not all items match")]
        public void SC006()
        {
            // Arrange
            var subject = new List<string> { "test1", "other", "test3" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().AllMatch("^test\\d$");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.AllMatch, result.Error.Code);
        }

        #endregion

        #region ContainEquivalentOf / NotContainEquivalentOf

        [Fact(DisplayName = "SC-007: ContainEquivalentOf succeeds with case-insensitive match")]
        public void SC007()
        {
            // Arrange
            var subject = new List<string> { "Apple", "Banana", "Cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().ContainEquivalentOf("apple");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-008: ContainEquivalentOf fails when no equivalent found")]
        public void SC008()
        {
            // Arrange
            var subject = new List<string> { "Apple", "Banana", "Cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().ContainEquivalentOf("grape");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.ContainEquivalentOf, result.Error.Code);
        }

        [Fact(DisplayName = "SC-009: NotContainEquivalentOf succeeds when no equivalent found")]
        public void SC009()
        {
            // Arrange
            var subject = new List<string> { "Apple", "Banana", "Cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainEquivalentOf("grape");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-010: NotContainEquivalentOf fails with case-insensitive match")]
        public void SC010()
        {
            // Arrange
            var subject = new List<string> { "Apple", "Banana", "Cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainEquivalentOf("APPLE");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.NotContainEquivalentOf, result.Error.Code);
        }

        #endregion

        #region OnlyContainNullOrEmpty / NotContainNullOrEmpty

        [Fact(DisplayName = "SC-011: OnlyContainNullOrEmpty succeeds")]
        public void SC011()
        {
            // Arrange
            var subject = new List<string?> { "", null, "" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().OnlyContainNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-012: OnlyContainNullOrEmpty fails when non-empty present")]
        public void SC012()
        {
            // Arrange
            var subject = new List<string?> { "", "hello", null };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().OnlyContainNullOrEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.OnlyContainNullOrEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "SC-013: NotContainNullOrEmpty succeeds")]
        public void SC013()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-014: NotContainNullOrEmpty fails when null present")]
        public void SC014()
        {
            // Arrange
            var subject = new List<string?> { "apple", null, "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainNullOrEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.NotContainNullOrEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "SC-015: NotContainNullOrEmpty fails when empty present")]
        public void SC015()
        {
            // Arrange
            var subject = new List<string> { "apple", "", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotContainNullOrEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.NotContainNullOrEmpty, result.Error.Code);
        }

        #endregion

        #region Equal

        [Fact(DisplayName = "SC-016: Equal succeeds when collections match")]
        public void SC016()
        {
            // Arrange
            var subject = new List<string> { "a", "b", "c" };
            var expected = new List<string> { "a", "b", "c" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().Equal(expected);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-017: Equal fails when collections differ")]
        public void SC017()
        {
            // Arrange
            var subject = new List<string> { "a", "b", "c" };
            var expected = new List<string> { "a", "x", "c" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().Equal(expected);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(StringCollectionAssertionCodes.Equal, result.Error.Code);
        }

        #endregion

        #region Standard Collection Assertions

        [Fact(DisplayName = "SC-018: BeEmpty succeeds for empty collection")]
        public void SC018()
        {
            // Arrange
            var subject = new List<string>();

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-019: NotBeEmpty succeeds for non-empty collection")]
        public void SC019()
        {
            // Arrange
            var subject = new List<string> { "hello" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-020: HaveCount succeeds")]
        public void SC020()
        {
            // Arrange
            var subject = new List<string> { "a", "b", "c" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().HaveCount(3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-021: Contain succeeds")]
        public void SC021()
        {
            // Arrange
            var subject = new List<string> { "a", "b", "c" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().Contain("b");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-022: HaveElementAt succeeds")]
        public void SC022()
        {
            // Arrange
            var subject = new List<string> { "a", "b", "c" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().HaveElementAt(1, "b");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-023: BeInAscendingOrder succeeds")]
        public void SC023()
        {
            // Arrange
            var subject = new List<string> { "apple", "banana", "cherry" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().BeInAscendingOrder();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "SC-024: BeInDescendingOrder succeeds")]
        public void SC024()
        {
            // Arrange
            var subject = new List<string> { "cherry", "banana", "apple" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should().BeInDescendingOrder();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "SC-025: Chaining string collection assertions works")]
        public void SC025()
        {
            // Arrange
            var subject = new List<string> { "test1", "test2", "test3" };

            // Act
            Result<IEnumerable<string?>?, Error> result = subject.Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.AllMatch("^test\\d$")
                .And.NotContainNullOrEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
