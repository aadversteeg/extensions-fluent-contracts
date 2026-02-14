using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for TimeSpan assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class TimeSpanAssertionsBase<TSelf> : Assertions<TimeSpan?, TSelf>
        where TSelf : TimeSpanAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSpanAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The TimeSpan value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected TimeSpanAssertionsBase(TimeSpan? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable TimeSpan has a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                TimeSpanAssertionCodes.HaveValue,
                "Expected TimeSpan to have a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable TimeSpan does not have a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                TimeSpanAssertionCodes.NotHaveValue,
                $"Did not expect TimeSpan to have a value but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value == expected,
                TimeSpanAssertionCodes.Be,
                Subject.HasValue
                    ? $"Expected TimeSpan to be '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(TimeSpan unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue || s.Value != unexpected,
                TimeSpanAssertionCodes.NotBe,
                $"Did not expect TimeSpan to be '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is positive (greater than zero).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BePositive(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value > TimeSpan.Zero,
                TimeSpanAssertionCodes.BePositive,
                Subject.HasValue
                    ? $"Expected TimeSpan to be positive but found '{Subject}'"
                    : "Expected TimeSpan to be positive but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is negative (less than zero).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNegative(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value < TimeSpan.Zero,
                TimeSpanAssertionCodes.BeNegative,
                Subject.HasValue
                    ? $"Expected TimeSpan to be negative but found '{Subject}'"
                    : "Expected TimeSpan to be negative but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is greater than the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeGreaterThan(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value > expected,
                TimeSpanAssertionCodes.BeGreaterThan,
                Subject.HasValue
                    ? $"Expected TimeSpan to be greater than '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be greater than '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is greater than or equal to the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeGreaterThanOrEqualTo(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value >= expected,
                TimeSpanAssertionCodes.BeGreaterThanOrEqualTo,
                Subject.HasValue
                    ? $"Expected TimeSpan to be greater than or equal to '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be greater than or equal to '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is less than the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeLessThan(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value < expected,
                TimeSpanAssertionCodes.BeLessThan,
                Subject.HasValue
                    ? $"Expected TimeSpan to be less than '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be less than '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is less than or equal to the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeLessThanOrEqualTo(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value <= expected,
                TimeSpanAssertionCodes.BeLessThanOrEqualTo,
                Subject.HasValue
                    ? $"Expected TimeSpan to be less than or equal to '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be less than or equal to '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is within a specified precision of the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="precision">The maximum amount the values may differ.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeCloseTo(TimeSpan expected, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && (s.Value - expected).Duration() <= precision,
                TimeSpanAssertionCodes.BeCloseTo,
                Subject.HasValue
                    ? $"Expected TimeSpan to be within '{precision}' of '{expected}' but found '{Subject}'"
                    : $"Expected TimeSpan to be within '{precision}' of '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("precision", precision.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the TimeSpan is not within a specified precision of the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="precision">The minimum amount the values must differ.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeCloseTo(TimeSpan unexpected, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue || (s.Value - unexpected).Duration() > precision,
                TimeSpanAssertionCodes.NotBeCloseTo,
                $"Did not expect TimeSpan to be within '{precision}' of '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("precision", precision.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
