using System;
using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;
using Xunit;

namespace UnitTests.Extensions.Assertions.Base
{
    public class AssertionScopeTests
    {
        [Fact(DisplayName = "AS-001: All() with all passing returns success")]
        public void AS001()
        {
            // Arrange & Act
            var result = AssertionScope.All(
                () => "Apple".Should().StartWithA(),
                () => "Apricot".Should().StartWithA(),
                () => "Avocado".Should().StartWithA()
            );

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AS-002: All() with one failure returns that error")]
        public void AS002()
        {
            // Arrange & Act
            var result = AssertionScope.All(
                () => "Apple".Should().StartWithA(),
                () => "Banana".Should().StartWithA(),
                () => "Avocado".Should().StartWithA()
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Single(result.Error);
            Assert.Equal(TestAssertionCodes.StartWithA, result.Error[0].Code);
        }

        [Fact(DisplayName = "AS-003: All() with multiple failures returns all errors")]
        public void AS003()
        {
            // Arrange & Act
            var result = AssertionScope.All(
                () => "Banana".Should().StartWithA(),
                () => "Cherry".Should().StartWithA(),
                () => "Date".Should().StartWithA()
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(3, result.Error.Count);
            Assert.All(result.Error, e => Assert.Equal(TestAssertionCodes.StartWithA, e.Code));
        }

        [Fact(DisplayName = "AS-004: All() with no assertions returns success")]
        public void AS004()
        {
            // Arrange & Act
            var result = AssertionScope.All();

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "AS-005: All() evaluates all assertions regardless of failures")]
        public void AS005()
        {
            // Arrange
            var evaluationCount = 0;
            Func<VoidResult<Error>> trackingAssertion = () =>
            {
                evaluationCount++;
                return "Banana".Should().StartWithA();
            };

            // Act
            var result = AssertionScope.All(
                trackingAssertion,
                trackingAssertion,
                trackingAssertion
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(3, evaluationCount);
            Assert.Equal(3, result.Error.Count);
        }

        [Fact(DisplayName = "AS-006: All() with mixed pass/fail returns only failures")]
        public void AS006()
        {
            // Arrange & Act
            var result = AssertionScope.All(
                () => "Apple".Should().StartWithA(),   // pass
                () => "Banana".Should().StartWithA(),  // fail
                () => "Apricot".Should().StartWithA(), // pass
                () => "Cherry".Should().StartWithA()   // fail
            );

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(2, result.Error.Count);
        }
    }
}
