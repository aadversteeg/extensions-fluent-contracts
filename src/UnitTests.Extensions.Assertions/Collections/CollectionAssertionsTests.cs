using System.Collections.Generic;
using Ave.Extensions.Assertions.Collections;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Collections
{
    public class CollectionAssertionsTests
    {
        #region BeEmpty / NotBeEmpty

        [Fact(DisplayName = "CA-001: BeEmpty succeeds for empty collection")]
        public void CA001()
        {
            // Arrange
            var subject = new List<int>();

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-002: BeEmpty fails for non-empty collection")]
        public void CA002()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.BeEmpty, result.Error.Code);
        }

        [Fact(DisplayName = "CA-003: NotBeEmpty succeeds for non-empty collection")]
        public void CA003()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-004: NotBeEmpty fails for empty collection")]
        public void CA004()
        {
            // Arrange
            var subject = new List<int>();

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().NotBeEmpty();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.NotBeEmpty, result.Error.Code);
        }

        #endregion

        #region HaveCount

        [Fact(DisplayName = "CA-005: HaveCount succeeds when count matches")]
        public void CA005()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveCount(3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-006: HaveCount fails when count does not match")]
        public void CA006()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveCount(5);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.HaveCount, result.Error.Code);
        }

        [Fact(DisplayName = "CA-007: HaveCountGreaterThan succeeds")]
        public void CA007()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveCountGreaterThan(3);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-008: HaveCountLessThan succeeds")]
        public void CA008()
        {
            // Arrange
            var subject = new List<int> { 1, 2 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveCountLessThan(5);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Contain / NotContain

        [Fact(DisplayName = "CA-009: Contain succeeds when item is in collection")]
        public void CA009()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().Contain(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-010: Contain fails when item is not in collection")]
        public void CA010()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().Contain(5);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.Contain, result.Error.Code);
        }

        [Fact(DisplayName = "CA-011: NotContain succeeds when item is not in collection")]
        public void CA011()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().NotContain(5);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-012: NotContain fails when item is in collection")]
        public void CA012()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().NotContain(2);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.NotContain, result.Error.Code);
        }

        #endregion

        #region ContainSingle

        [Fact(DisplayName = "CA-013: ContainSingle succeeds for single item collection")]
        public void CA013()
        {
            // Arrange
            var subject = new List<int> { 42 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().ContainSingle();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-014: ContainSingle fails for multi-item collection")]
        public void CA014()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().ContainSingle();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.ContainSingle, result.Error.Code);
        }

        [Fact(DisplayName = "CA-015: ContainSingle with predicate succeeds")]
        public void CA015()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().ContainSingle(x => x > 4);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region OnlyContain

        [Fact(DisplayName = "CA-016: OnlyContain succeeds when all items match")]
        public void CA016()
        {
            // Arrange
            var subject = new List<int> { 2, 4, 6, 8 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().OnlyContain(x => x % 2 == 0);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-017: OnlyContain fails when some items do not match")]
        public void CA017()
        {
            // Arrange
            var subject = new List<int> { 2, 3, 4, 6 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().OnlyContain(x => x % 2 == 0);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.OnlyContain, result.Error.Code);
        }

        #endregion

        #region BeSubsetOf

        [Fact(DisplayName = "CA-018: BeSubsetOf succeeds")]
        public void CA018()
        {
            // Arrange
            var subject = new List<int> { 1, 2 };
            var superset = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeSubsetOf(superset);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-019: BeSubsetOf fails when not a subset")]
        public void CA019()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 10 };
            var superset = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeSubsetOf(superset);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.BeSubsetOf, result.Error.Code);
        }

        #endregion

        #region HaveElementAt

        [Fact(DisplayName = "CA-020: HaveElementAt succeeds")]
        public void CA020()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveElementAt(1, 2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-021: HaveElementAt fails when element differs")]
        public void CA021()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().HaveElementAt(1, 99);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.HaveElementAt, result.Error.Code);
        }

        #endregion

        #region BeInAscendingOrder / BeInDescendingOrder

        [Fact(DisplayName = "CA-022: BeInAscendingOrder succeeds")]
        public void CA022()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeInAscendingOrder();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "CA-023: BeInAscendingOrder fails when not ordered")]
        public void CA023()
        {
            // Arrange
            var subject = new List<int> { 1, 3, 2, 4, 5 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeInAscendingOrder();

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(CollectionAssertionCodes.BeInAscendingOrder, result.Error.Code);
        }

        [Fact(DisplayName = "CA-024: BeInDescendingOrder succeeds")]
        public void CA024()
        {
            // Arrange
            var subject = new List<int> { 5, 4, 3, 2, 1 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should().BeInDescendingOrder();

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion

        #region Chaining

        [Fact(DisplayName = "CA-025: Chaining multiple collection assertions works")]
        public void CA025()
        {
            // Arrange
            var subject = new List<int> { 1, 2, 3 };

            // Act
            Result<IEnumerable<int>?, Error> result = subject.Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.Contain(2);

            // Assert
            Assert.True(result.IsSuccess);
        }

        #endregion
    }
}
