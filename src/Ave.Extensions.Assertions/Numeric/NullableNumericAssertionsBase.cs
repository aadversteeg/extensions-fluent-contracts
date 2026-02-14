using System;
using System.Collections.Generic;
using System.Linq;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for nullable numeric assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class NullableNumericAssertionsBase<T, TSelf> : Assertions<T?, TSelf>
        where T : struct, IComparable<T>
        where TSelf : NullableNumericAssertionsBase<T, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableNumericAssertionsBase{T, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The nullable numeric value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected NullableNumericAssertionsBase(T? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable numeric has a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                NumericAssertionCodes.HaveValue,
                "Expected a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable numeric does not have a value (is null).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                NumericAssertionCodes.NotHaveValue,
                $"Did not expect a value but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable numeric is null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNull(string because = "", params object[] becauseArgs)
        {
            return NotHaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the nullable numeric is not null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeNull(string because = "", params object[] becauseArgs)
        {
            return HaveValue(because, becauseArgs);
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
                s => s.HasValue && s.Value.CompareTo(expected) == 0,
                NumericAssertionCodes.Be,
                Subject.HasValue
                    ? $"Expected '{expected}' but found '{Subject.Value}'"
                    : $"Expected '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => !s.HasValue || s.Value.CompareTo(unexpected) != 0,
                NumericAssertionCodes.NotBe,
                $"Did not expect '{unexpected}'",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(default!) > 0,
                NumericAssertionCodes.BePositive,
                Subject.HasValue
                    ? $"Expected positive value but found '{Subject.Value}'"
                    : "Expected positive value but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(default!) < 0,
                NumericAssertionCodes.BeNegative,
                Subject.HasValue
                    ? $"Expected negative value but found '{Subject.Value}'"
                    : "Expected negative value but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(expected) > 0,
                NumericAssertionCodes.BeGreaterThan,
                Subject.HasValue
                    ? $"Expected value greater than '{expected}' but found '{Subject.Value}'"
                    : $"Expected value greater than '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(expected) >= 0,
                NumericAssertionCodes.BeGreaterThanOrEqualTo,
                Subject.HasValue
                    ? $"Expected value greater than or equal to '{expected}' but found '{Subject.Value}'"
                    : $"Expected value greater than or equal to '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(expected) < 0,
                NumericAssertionCodes.BeLessThan,
                Subject.HasValue
                    ? $"Expected value less than '{expected}' but found '{Subject.Value}'"
                    : $"Expected value less than '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(expected) <= 0,
                NumericAssertionCodes.BeLessThanOrEqualTo,
                Subject.HasValue
                    ? $"Expected value less than or equal to '{expected}' but found '{Subject.Value}'"
                    : $"Expected value less than or equal to '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && s.Value.CompareTo(minimumValue) >= 0 && s.Value.CompareTo(maximumValue) <= 0,
                NumericAssertionCodes.BeInRange,
                Subject.HasValue
                    ? $"Expected value between '{minimumValue}' and '{maximumValue}' but found '{Subject.Value}'"
                    : $"Expected value between '{minimumValue}' and '{maximumValue}' but found null",
                e => e.With("minimum", minimumValue)
                      .With("maximum", maximumValue)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => !s.HasValue || s.Value.CompareTo(minimumValue) < 0 || s.Value.CompareTo(maximumValue) > 0,
                NumericAssertionCodes.NotBeInRange,
                Subject.HasValue
                    ? $"Did not expect value between '{minimumValue}' and '{maximumValue}' but found '{Subject.Value}'"
                    : $"Did not expect value between '{minimumValue}' and '{maximumValue}'",
                e => e.With("minimum", minimumValue)
                      .With("maximum", maximumValue)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && validList.Any(v => s.Value.CompareTo(v) == 0),
                NumericAssertionCodes.BeOneOf,
                Subject.HasValue
                    ? $"Expected value to be one of [{string.Join(", ", validList)}] but found '{Subject.Value}'"
                    : $"Expected value to be one of [{string.Join(", ", validList)}] but found null",
                e => e.With("validValues", string.Join(", ", validList))
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                s => s.HasValue && predicate(s.Value),
                NumericAssertionCodes.Match,
                Subject.HasValue
                    ? $"Expected value to match predicate but found '{Subject.Value}'"
                    : "Expected value to match predicate but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
