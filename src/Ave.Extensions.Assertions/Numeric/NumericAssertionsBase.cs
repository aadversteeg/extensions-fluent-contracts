using System;
using System.Collections.Generic;
using System.Linq;

namespace Ave.Extensions.Assertions.Numeric
{
    /// <summary>
    /// Base class for numeric assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class NumericAssertionsBase<T, TSelf> : Assertions<T, TSelf>
        where T : struct, IComparable<T>
        where TSelf : NumericAssertionsBase<T, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericAssertionsBase{T, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The numeric value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected NumericAssertionsBase(T subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the numeric value is exactly the same as the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(expected) == 0,
                NumericAssertionCodes.Be,
                $"Expected '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is not the same as the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(T unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(unexpected) != 0,
                NumericAssertionCodes.NotBe,
                $"Did not expect '{unexpected}'",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is greater than zero.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BePositive(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(default!) > 0,
                NumericAssertionCodes.BePositive,
                $"Expected positive value but found '{Subject}'",
                e => e.With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is less than zero.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNegative(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(default!) < 0,
                NumericAssertionCodes.BeNegative,
                $"Expected negative value but found '{Subject}'",
                e => e.With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is greater than the specified value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeGreaterThan(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(expected) > 0,
                NumericAssertionCodes.BeGreaterThan,
                $"Expected value greater than '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is greater than or equal to the specified value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeGreaterThanOrEqualTo(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(expected) >= 0,
                NumericAssertionCodes.BeGreaterThanOrEqualTo,
                $"Expected value greater than or equal to '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is less than the specified value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeLessThan(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(expected) < 0,
                NumericAssertionCodes.BeLessThan,
                $"Expected value less than '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is less than or equal to the specified value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeLessThanOrEqualTo(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(expected) <= 0,
                NumericAssertionCodes.BeLessThanOrEqualTo,
                $"Expected value less than or equal to '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is within a range (inclusive).
        /// </summary>
        /// <param name="minimumValue">The minimum value of the range.</param>
        /// <param name="maximumValue">The maximum value of the range.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeInRange(T minimumValue, T maximumValue, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(minimumValue) >= 0 && s.CompareTo(maximumValue) <= 0,
                NumericAssertionCodes.BeInRange,
                $"Expected value between '{minimumValue}' and '{maximumValue}' but found '{Subject}'",
                e => e.With("minimum", minimumValue)
                      .With("maximum", maximumValue)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is not within a range.
        /// </summary>
        /// <param name="minimumValue">The minimum value of the range.</param>
        /// <param name="maximumValue">The maximum value of the range.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeInRange(T minimumValue, T maximumValue, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.CompareTo(minimumValue) < 0 || s.CompareTo(maximumValue) > 0,
                NumericAssertionCodes.NotBeInRange,
                $"Did not expect value between '{minimumValue}' and '{maximumValue}' but found '{Subject}'",
                e => e.With("minimum", minimumValue)
                      .With("maximum", maximumValue)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the numeric value is one of the specified values.
        /// </summary>
        /// <param name="validValues">The valid values.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOneOf(params T[] validValues)
        {
            return BeOneOf(validValues, string.Empty);
        }

        /// <summary>
        /// Asserts that the numeric value is one of the specified values.
        /// </summary>
        /// <param name="validValues">The valid values.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOneOf(IEnumerable<T> validValues, string because = "", params object[] becauseArgs)
        {
            var validList = validValues?.ToList() ?? new List<T>();
            return Assert(
                s => validList.Any(v => s.CompareTo(v) == 0),
                NumericAssertionCodes.BeOneOf,
                $"Expected value to be one of [{string.Join(", ", validList)}] but found '{Subject}'",
                e => e.With("validValues", string.Join(", ", validList))
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the predicate is satisfied.
        /// </summary>
        /// <param name="predicate">The predicate which must be satisfied.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf Match(Func<T, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Assert(
                predicate,
                NumericAssertionCodes.Match,
                $"Expected value to match predicate but found '{Subject}'",
                e => e.With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
