using Ave.Extensions.Assertions;
using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Dictionaries
{
    public class DictionaryAssertionsTests
    {
        #region BeNull / NotBeNull

        [Fact(DisplayName = "DA-001: BeNull succeeds for null dictionary")]
        public void DA001()
        {
            // Arrange
            Dictionary<string, int>? subject = null;

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().BeNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-002: BeNull fails for non-null dictionary")]
        public void DA002()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().BeNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.BeNull, result.Error.Code);
        }

        [Fact(DisplayName = "DA-003: NotBeNull succeeds for non-null dictionary")]
        public void DA003()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotBeNull();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-004: NotBeNull fails for null dictionary")]
        public void DA004()
        {
            // Arrange
            Dictionary<string, int>? subject = null;

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotBeNull();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.NotBeNull, result.Error.Code);
        }

        #endregion

        #region BeEmpty / NotBeEmpty

        [Fact(DisplayName = "DA-005: BeEmpty succeeds for empty dictionary")]
        public void DA005()
        {
            // Arrange
            var subject = new Dictionary<string, int>();

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-006: BeEmpty fails for non-empty dictionary")]
        public void DA006()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.BeEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "DA-007: NotBeEmpty succeeds for non-empty dictionary")]
        public void DA007()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-008: NotBeEmpty fails for empty dictionary")]
        public void DA008()
        {
            // Arrange
            var subject = new Dictionary<string, int>();

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.NotBeEmpty, result.Error.Code);
        }

        #endregion

        #region HaveCount

        [Fact(DisplayName = "DA-009: HaveCount succeeds when count matches")]
        public void DA009()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().HaveCount(3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-010: HaveCount fails when count does not match")]
        public void DA010()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().HaveCount(5);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.HaveCount, result.Error.Code);
        }

        #endregion

        #region ContainKey / NotContainKey

        [Fact(DisplayName = "DA-011: ContainKey succeeds when key exists")]
        public void DA011()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKey("a");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-012: ContainKey fails when key does not exist")]
        public void DA012()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKey("x");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.ContainKey, result.Error.Code);
        }

        [Fact(DisplayName = "DA-013: NotContainKey succeeds when key does not exist")]
        public void DA013()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainKey("x");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-014: NotContainKey fails when key exists")]
        public void DA014()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainKey("a");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.NotContainKey, result.Error.Code);
        }

        #endregion

        #region ContainKeys

        [Fact(DisplayName = "DA-015: ContainKeys succeeds when all keys exist")]
        public void DA015()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKeys("a", "b");

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-016: ContainKeys fails when some keys don't exist")]
        public void DA016()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKeys("a", "x");

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.ContainKeys, result.Error.Code);
        }

        #endregion

        #region ContainValue / NotContainValue

        [Fact(DisplayName = "DA-017: ContainValue succeeds when value exists")]
        public void DA017()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainValue(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-018: ContainValue fails when value does not exist")]
        public void DA018()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainValue(99);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.ContainValue, result.Error.Code);
        }

        [Fact(DisplayName = "DA-019: NotContainValue succeeds when value does not exist")]
        public void DA019()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainValue(99);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-020: NotContainValue fails when value exists")]
        public void DA020()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainValue(2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.NotContainValue, result.Error.Code);
        }

        #endregion

        #region ContainKeyValuePair / NotContainKeyValuePair

        [Fact(DisplayName = "DA-021: ContainKeyValuePair succeeds when pair exists")]
        public void DA021()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKeyValuePair("a", 1);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-022: ContainKeyValuePair fails when key exists but value differs")]
        public void DA022()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKeyValuePair("a", 99);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.ContainKeyValuePair, result.Error.Code);
        }

        [Fact(DisplayName = "DA-023: ContainKeyValuePair fails when key doesn't exist")]
        public void DA023()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().ContainKeyValuePair("x", 1);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.ContainKeyValuePair, result.Error.Code);
        }

        [Fact(DisplayName = "DA-024: NotContainKeyValuePair succeeds when pair doesn't exist")]
        public void DA024()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainKeyValuePair("a", 99);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-025: NotContainKeyValuePair fails when pair exists")]
        public void DA025()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().NotContainKeyValuePair("a", 1);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.NotContainKeyValuePair, result.Error.Code);
        }

        #endregion

        #region HaveSameCount

        [Fact(DisplayName = "DA-026: HaveSameCount succeeds when counts match")]
        public void DA026()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 } };
            var other = new List<int> { 1, 2, 3 };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().HaveSameCount(other);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "DA-027: HaveSameCount fails when counts differ")]
        public void DA027()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 } };
            var other = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should().HaveSameCount(other);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(DictionaryAssertionCodes.HaveSameCount, result.Error.Code);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "DA-028: Chaining dictionary assertions works")]
        public void DA028()
        {
            // Arrange
            var subject = new Dictionary<string, int> { { "a", 1 }, { "b", 2 }, { "c", 3 } };

            // Act
            Result<IDictionary<string, int>?, Error> result = subject.Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.ContainKey("a")
                .And.ContainValue(2)
                .And.ContainKeyValuePair("c", 3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
