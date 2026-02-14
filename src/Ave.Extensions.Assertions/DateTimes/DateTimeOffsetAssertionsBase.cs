using System;

namespace Ave.Extensions.Assertions.DateTimes
{
    /// <summary>
    /// Base class for DateTimeOffset assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class DateTimeOffsetAssertionsBase<TSelf> : Assertions<DateTimeOffset?, TSelf>
        where TSelf : DateTimeOffsetAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeOffsetAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The DateTimeOffset value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected DateTimeOffsetAssertionsBase(DateTimeOffset? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable DateTimeOffset has a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                DateTimeOffsetAssertionCodes.HaveValue,
                "Expected DateTimeOffset to have a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable DateTimeOffset does not have a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                DateTimeOffsetAssertionCodes.NotHaveValue,
                $"Did not expect DateTimeOffset to have a value but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value == expected,
                DateTimeOffsetAssertionCodes.Be,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(DateTimeOffset unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue || s.Value != unexpected,
                DateTimeOffsetAssertionCodes.NotBe,
                $"Did not expect DateTimeOffset to be '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is within a specified precision of the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="precision">The maximum amount the values may differ.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeCloseTo(DateTimeOffset expected, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && (s.Value - expected).Duration() <= precision,
                DateTimeOffsetAssertionCodes.BeCloseTo,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be within '{precision}' of '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be within '{precision}' of '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("precision", precision.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is not within a specified precision of the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="precision">The minimum amount the values must differ.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeCloseTo(DateTimeOffset unexpected, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue || (s.Value - unexpected).Duration() > precision,
                DateTimeOffsetAssertionCodes.NotBeCloseTo,
                $"Did not expect DateTimeOffset to be within '{precision}' of '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("precision", precision.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is before the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeBefore(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value < expected,
                DateTimeOffsetAssertionCodes.BeBefore,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be before '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be before '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is on or before the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOnOrBefore(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value <= expected,
                DateTimeOffsetAssertionCodes.BeOnOrBefore,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be on or before '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be on or before '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is after the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeAfter(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value > expected,
                DateTimeOffsetAssertionCodes.BeAfter,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be after '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be after '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset is on or after the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOnOrAfter(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value >= expected,
                DateTimeOffsetAssertionCodes.BeOnOrAfter,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to be on or after '{expected}' but found '{Subject}'"
                    : $"Expected DateTimeOffset to be on or after '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset has the specified offset.
        /// </summary>
        /// <param name="expected">The expected offset.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveOffset(TimeSpan expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Offset == expected,
                DateTimeOffsetAssertionCodes.HaveOffset,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to have offset '{expected}' but found '{Subject.Value.Offset}'"
                    : $"Expected DateTimeOffset to have offset '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.Offset.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTimeOffset represents the same date as the expected value.
        /// </summary>
        /// <param name="expected">The expected date.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeSameDateAs(DateTimeOffset expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Date == expected.Date,
                DateTimeOffsetAssertionCodes.BeSameDateAs,
                Subject.HasValue
                    ? $"Expected DateTimeOffset to have date '{expected.Date:yyyy-MM-dd}' but found '{Subject.Value.Date:yyyy-MM-dd}'"
                    : $"Expected DateTimeOffset to have date '{expected.Date:yyyy-MM-dd}' but found null",
                e => e.With("expected", expected.Date.ToString("yyyy-MM-dd"))
                      .With("actual", Subject?.Date.ToString("yyyy-MM-dd") ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
