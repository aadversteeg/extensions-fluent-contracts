using System;
using System.Collections.Generic;
using System.Linq;

namespace Ave.Extensions.Assertions.Collections
{
    /// <summary>
    /// Base class containing assertion methods for collections.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <typeparam name="TSelf">The concrete assertion type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class CollectionAssertionsBase<T, TSelf> : Assertions<IEnumerable<T>?, TSelf>
        where TSelf : CollectionAssertionsBase<T, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertionsBase{T, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The collection to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure instead of recording it.</param>
        protected CollectionAssertionsBase(IEnumerable<T>? subject, bool throwOnFailure) : base(subject, throwOnFailure)
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
                CollectionAssertionCodes.BeEmpty,
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
                CollectionAssertionCodes.NotBeEmpty,
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
                CollectionAssertionCodes.HaveCount,
                Subject is null
                    ? $"Expected collection with {expected} item(s) but found null"
                    : $"Expected collection with {expected} item(s) but found {Subject.Count()} item(s)",
                e => e.With("expectedCount", expected)
                      .With("actualCount", Subject?.Count() ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
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
        /// Asserts that the collection contains the specified item.
        /// </summary>
        /// <param name="expected">The item that should be in the collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Contain(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Contains(expected),
                CollectionAssertionCodes.Contain,
                Subject is null
                    ? $"Expected collection to contain '{expected}' but found null"
                    : $"Expected collection to contain '{expected}' but it was not found",
                e => e.With("expected", expected ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the collection does not contain the specified item.
        /// </summary>
        /// <param name="unexpected">The item that should not be in the collection.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotContain(T unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.Contains(unexpected),
                CollectionAssertionCodes.NotContain,
                $"Did not expect collection to contain '{unexpected}' but it was found",
                e => e.With("unexpected", unexpected ?? (object)"(null)")
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
        public TSelf ContainSingle(Func<T, bool> predicate, string because = "", params object[] becauseArgs)
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
        public TSelf OnlyContain(Func<T, bool> predicate, string because = "", params object[] becauseArgs)
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
        public TSelf BeSubsetOf(IEnumerable<T> expectedSuperset, string because = "", params object[] becauseArgs)
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
        public TSelf HaveElementAt(int index, T expected, string because = "", params object[] becauseArgs)
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
                    ? $"Expected element at index {index} to be '{expected}' but found null collection"
                    : $"Expected element at index {index} to be '{expected}'",
                e => e.With("index", index)
                      .With("expected", expected ?? (object)"(null)")
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
                    var comparer = Comparer<T>.Default;
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
                    var comparer = Comparer<T>.Default;
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
