using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class containing assertion methods for string collections.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class StringCollectionAssertionsBase<TSelf> : Assertions<IEnumerable<string?>?, TSelf>
        where TSelf : StringCollectionAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringCollectionAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The string collection to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure instead of recording it.</param>
        protected StringCollectionAssertionsBase(IEnumerable<string?>? subject, bool throwOnFailure) : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the collection contains no items.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && !s.Any(),
                StringCollectionAssertionCodes.BeEmpty,
                Subject is null
                    ? "Expected empty collection but found null"
                    : $"Expected empty collection but found {Subject.Count()} item(s)",
                e => e.With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains at least one item.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Any(),
                StringCollectionAssertionCodes.NotBeEmpty,
                Subject is null
                    ? "Expected non-empty collection but found null"
                    : "Expected non-empty collection but found empty collection",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains exactly the specified number of items.
        /// </summary>
        /// <param name="expected">The expected number of items.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveCount(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count() == expected,
                StringCollectionAssertionCodes.HaveCount,
                Subject is null
                    ? $"Expected collection with {expected} item(s) but found null"
                    : $"Expected collection with {expected} item(s) but found {Subject.Count()} item(s)",
                e => e.With("expectedCount", expected)
                      .With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains the specified item.
        /// </summary>
        /// <param name="expected">The item that should be in the collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Contain(string? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Contains(expected),
                StringCollectionAssertionCodes.Contain,
                Subject is null
                    ? $"Expected collection to contain '{expected ?? "(null)"}' but found null"
                    : $"Expected collection to contain '{expected ?? "(null)"}' but it was not found",
                e => e.With("expected", expected ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection does not contain the specified item.
        /// </summary>
        /// <param name="unexpected">The item that should not be in the collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotContain(string? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.Contains(unexpected),
                StringCollectionAssertionCodes.NotContain,
                $"Did not expect collection to contain '{unexpected ?? "(null)"}' but it was found",
                e => e.With("unexpected", unexpected ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains at least one string matching the specified regular expression pattern.
        /// </summary>
        /// <param name="wildcardPattern">The regular expression pattern to match.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf ContainMatch(string wildcardPattern, string because = "", params object[] becauseArgs)
        {
            if (wildcardPattern is null)
            {
                throw new ArgumentNullException(nameof(wildcardPattern));
            }

            var regex = new Regex(wildcardPattern);
            return Assert(
                s => s is not null && s.Any(item => item is not null && regex.IsMatch(item)),
                StringCollectionAssertionCodes.ContainMatch,
                Subject is null
                    ? $"Expected collection to contain a string matching '{wildcardPattern}' but found null"
                    : $"Expected collection to contain a string matching '{wildcardPattern}' but no match was found",
                e => e.With("pattern", wildcardPattern)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection does not contain any string matching the specified regular expression pattern.
        /// </summary>
        /// <param name="wildcardPattern">The regular expression pattern that should not match.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotContainMatch(string wildcardPattern, string because = "", params object[] becauseArgs)
        {
            if (wildcardPattern is null)
            {
                throw new ArgumentNullException(nameof(wildcardPattern));
            }

            var regex = new Regex(wildcardPattern);
            return Assert(
                s => s is null || !s.Any(item => item is not null && regex.IsMatch(item)),
                StringCollectionAssertionCodes.NotContainMatch,
                $"Did not expect collection to contain a string matching '{wildcardPattern}' but a match was found",
                e => e.With("pattern", wildcardPattern)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that all strings in the collection match the specified regular expression pattern.
        /// </summary>
        /// <param name="wildcardPattern">The regular expression pattern that all items must match.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf AllMatch(string wildcardPattern, string because = "", params object[] becauseArgs)
        {
            if (wildcardPattern is null)
            {
                throw new ArgumentNullException(nameof(wildcardPattern));
            }

            var regex = new Regex(wildcardPattern);
            return Assert(
                s => s is not null && s.All(item => item is not null && regex.IsMatch(item)),
                StringCollectionAssertionCodes.AllMatch,
                Subject is null
                    ? $"Expected all strings in collection to match '{wildcardPattern}' but found null"
                    : $"Expected all strings in collection to match '{wildcardPattern}' but not all matched",
                e => e.With("pattern", wildcardPattern)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains a string equivalent to the expected string (case-insensitive comparison).
        /// </summary>
        /// <param name="expected">The expected string (case-insensitive).</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf ContainEquivalentOf(string? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Any(item =>
                    string.Equals(item, expected, StringComparison.OrdinalIgnoreCase)),
                StringCollectionAssertionCodes.ContainEquivalentOf,
                Subject is null
                    ? $"Expected collection to contain a string equivalent to '{expected ?? "(null)"}' but found null"
                    : $"Expected collection to contain a string equivalent to '{expected ?? "(null)"}' but it was not found",
                e => e.With("expected", expected ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection does not contain a string equivalent to the unexpected string (case-insensitive comparison).
        /// </summary>
        /// <param name="unexpected">The unexpected string (case-insensitive).</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotContainEquivalentOf(string? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.Any(item =>
                    string.Equals(item, unexpected, StringComparison.OrdinalIgnoreCase)),
                StringCollectionAssertionCodes.NotContainEquivalentOf,
                $"Did not expect collection to contain a string equivalent to '{unexpected ?? "(null)"}' but it was found",
                e => e.With("unexpected", unexpected ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection only contains null or empty strings.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf OnlyContainNullOrEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.All(item => string.IsNullOrEmpty(item)),
                StringCollectionAssertionCodes.OnlyContainNullOrEmpty,
                Subject is null
                    ? "Expected collection to only contain null or empty strings but found null"
                    : "Expected collection to only contain null or empty strings but non-empty strings were found",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection does not contain any null or empty strings.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotContainNullOrEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && !s.Any(item => string.IsNullOrEmpty(item)),
                StringCollectionAssertionCodes.NotContainNullOrEmpty,
                Subject is null
                    ? "Expected collection to not contain null or empty strings but found null"
                    : "Expected collection to not contain null or empty strings but null or empty strings were found",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the string collection is equal to the expected collection in both order and content.
        /// </summary>
        /// <param name="expected">The expected collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Equal(IEnumerable<string?> expected, string because = "", params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return Assert(
                s =>
                {
                    if (s is null) return false;
                    var subjectList = s.ToList();
                    var expectedList = expected.ToList();
                    return subjectList.SequenceEqual(expectedList);
                },
                StringCollectionAssertionCodes.Equal,
                Subject is null
                    ? "Expected collection to be equal to the expected collection but found null"
                    : "Expected collection to be equal to the expected collection but they differ",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains more than the specified number of items.
        /// </summary>
        /// <param name="expected">The number of items the collection should exceed.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveCountGreaterThan(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count() > expected,
                CollectionAssertionCodes.HaveCountGreaterThan,
                Subject is null
                    ? $"Expected collection with more than {expected} item(s) but found null"
                    : $"Expected collection with more than {expected} item(s) but found {Subject.Count()} item(s)",
                e => e.With("expectedMinimum", expected)
                      .With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains fewer than the specified number of items.
        /// </summary>
        /// <param name="expected">The number of items the collection should not exceed.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveCountLessThan(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count() < expected,
                CollectionAssertionCodes.HaveCountLessThan,
                Subject is null
                    ? $"Expected collection with fewer than {expected} item(s) but found null"
                    : $"Expected collection with fewer than {expected} item(s) but found {Subject.Count()} item(s)",
                e => e.With("expectedMaximum", expected)
                      .With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains exactly one item.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf ContainSingle(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count() == 1,
                CollectionAssertionCodes.ContainSingle,
                Subject is null
                    ? "Expected collection with single item but found null"
                    : $"Expected collection with single item but found {Subject.Count()} item(s)",
                e => e.With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection contains exactly one item matching the predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf ContainSingle(Func<string?, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Assert(
                s => s is not null && s.Count(predicate) == 1,
                CollectionAssertionCodes.ContainSingle,
                Subject is null
                    ? "Expected collection with single matching item but found null"
                    : $"Expected collection with single matching item but found {Subject.Count(predicate)} matching item(s)",
                e => e.With("matchingCount", Subject?.Count(predicate) ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that all items in the collection satisfy the predicate.
        /// </summary>
        /// <param name="predicate">The predicate that all items must satisfy.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf OnlyContain(Func<string?, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Assert(
                s => s is not null && s.All(predicate),
                CollectionAssertionCodes.OnlyContain,
                "Expected all items to satisfy predicate but some did not",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection is a subset of the specified superset.
        /// </summary>
        /// <param name="expectedSuperset">The superset that should contain all items from the collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expectedSuperset is null.</exception>
        public TSelf BeSubsetOf(IEnumerable<string?> expectedSuperset, string because = "", params object[] becauseArgs)
        {
            if (expectedSuperset is null)
            {
                throw new ArgumentNullException(nameof(expectedSuperset));
            }

            var supersetList = expectedSuperset.ToList();
            return Assert(
                s => s is not null && s.All(item => supersetList.Contains(item)),
                CollectionAssertionCodes.BeSubsetOf,
                "Expected collection to be a subset of the superset but it contains items not in the superset",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the element at the specified index is equal to the expected value.
        /// </summary>
        /// <param name="index">The index of the element.</param>
        /// <param name="expected">The expected value at that index.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveElementAt(int index, string? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s =>
                {
                    if (s is null) return false;
                    var list = s.ToList();
                    if (index < 0 || index >= list.Count) return false;
                    return Equals(list[index], expected);
                },
                CollectionAssertionCodes.HaveElementAt,
                Subject is null
                    ? $"Expected element at index {index} to be '{expected ?? "(null)"}' but found null collection"
                    : $"Expected element at index {index} to be '{expected ?? "(null)"}'",
                e => e.With("index", index)
                      .With("expected", expected ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection is in ascending order.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeInAscendingOrder(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s =>
                {
                    if (s is null) return false;
                    var list = s.ToList();
                    var comparer = Comparer<string?>.Default;
                    for (int i = 1; i < list.Count; i++)
                    {
                        if (comparer.Compare(list[i - 1], list[i]) > 0)
                            return false;
                    }
                    return true;
                },
                CollectionAssertionCodes.BeInAscendingOrder,
                "Expected collection to be in ascending order but it was not",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection is in descending order.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeInDescendingOrder(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s =>
                {
                    if (s is null) return false;
                    var list = s.ToList();
                    var comparer = Comparer<string?>.Default;
                    for (int i = 1; i < list.Count; i++)
                    {
                        if (comparer.Compare(list[i - 1], list[i]) < 0)
                            return false;
                    }
                    return true;
                },
                CollectionAssertionCodes.BeInDescendingOrder,
                "Expected collection to be in descending order but it was not",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
