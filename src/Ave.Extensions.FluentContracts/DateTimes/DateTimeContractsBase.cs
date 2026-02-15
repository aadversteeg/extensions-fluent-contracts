using System;
using System.Collections.Generic;
using System.Linq;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for DateTime contracts containing all contract methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class DateTimeContractsBase<TSelf> : Contracts<DateTime?, TSelf>
        where TSelf : DateTimeContractsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeContractsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The DateTime value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected DateTimeContractsBase(DateTime? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current DateTime is exactly equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf Be(DateTime expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                DateTimeContractCodes.Be,
                Subject.HasValue
                    ? $"Expected date and time to be '{expected}' but found '{Subject}'"
                    : $"Expected date and time to be '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is exactly equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf Be(DateTime? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                DateTimeContractCodes.Be,
                $"Expected date and time to be '{expected?.ToString() ?? "(null)"}' but found '{Subject?.ToString() ?? "(null)"}'",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBe(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                DateTimeContractCodes.NotBe,
                $"Expected date and time not to be '{unexpected}' but it is",
                e => e.With("unexpected", unexpected)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBe(DateTime? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                DateTimeContractCodes.NotBe,
                $"Expected date and time not to be '{unexpected?.ToString() ?? "(null)"}' but it is",
                e => e.With("unexpected", unexpected?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is within the specified time from the specified nearby time.
        /// </summary>
        /// <param name="nearbyTime">The expected time to compare the actual value with.</param>
        /// <param name="precision">The maximum amount of time which the two values may differ.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when precision is negative.</exception>
        public TSelf BeCloseTo(DateTime nearbyTime, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            if (precision < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), "Precision must not be negative.");
            }

            return Assert(
                s =>
                {
                    if (!s.HasValue) return false;
                    var difference = (s.Value - nearbyTime).Duration();
                    return difference <= precision;
                },
                DateTimeContractCodes.BeCloseTo,
                Subject.HasValue
                    ? $"Expected date and time to be within {precision} from '{nearbyTime}' but '{Subject}' was off by {(Subject.Value - nearbyTime).Duration()}"
                    : $"Expected date and time to be within {precision} from '{nearbyTime}' but found null",
                e => e.With("nearbyTime", nearbyTime)
                      .With("precision", precision)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is not within the specified time from the specified distant time.
        /// </summary>
        /// <param name="distantTime">The time to compare the actual value with.</param>
        /// <param name="precision">The maximum amount of time which the two values must differ.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when precision is negative.</exception>
        public TSelf NotBeCloseTo(DateTime distantTime, TimeSpan precision, string because = "", params object[] becauseArgs)
        {
            if (precision < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(precision), "Precision must not be negative.");
            }

            return Assert(
                s =>
                {
                    if (!s.HasValue) return true;
                    var difference = (s.Value - distantTime).Duration();
                    return difference > precision;
                },
                DateTimeContractCodes.NotBeCloseTo,
                $"Did not expect date and time to be within {precision} from '{distantTime}' but it was '{Subject}'",
                e => e.With("distantTime", distantTime)
                      .With("precision", precision)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is before the specified value.
        /// </summary>
        /// <param name="expected">The DateTime that the current value is expected to be before.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeBefore(DateTime expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s < expected,
                DateTimeContractCodes.BeBefore,
                Subject.HasValue
                    ? $"Expected date and time to be before '{expected}' but found '{Subject}'"
                    : $"Expected date and time to be before '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is not before the specified value.
        /// </summary>
        /// <param name="unexpected">The DateTime that the current value is not expected to be before.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeBefore(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            return BeOnOrAfter(unexpected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current DateTime is on or before the specified value.
        /// </summary>
        /// <param name="expected">The DateTime that the current value is expected to be on or before.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOnOrBefore(DateTime expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s <= expected,
                DateTimeContractCodes.BeOnOrBefore,
                Subject.HasValue
                    ? $"Expected date and time to be on or before '{expected}' but found '{Subject}'"
                    : $"Expected date and time to be on or before '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is neither on nor before the specified value.
        /// </summary>
        /// <param name="unexpected">The DateTime that the current value is not expected to be on nor before.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeOnOrBefore(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            return BeAfter(unexpected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current DateTime is after the specified value.
        /// </summary>
        /// <param name="expected">The DateTime that the current value is expected to be after.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeAfter(DateTime expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s > expected,
                DateTimeContractCodes.BeAfter,
                Subject.HasValue
                    ? $"Expected date and time to be after '{expected}' but found '{Subject}'"
                    : $"Expected date and time to be after '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is not after the specified value.
        /// </summary>
        /// <param name="unexpected">The DateTime that the current value is not expected to be after.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeAfter(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            return BeOnOrBefore(unexpected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current DateTime is on or after the specified value.
        /// </summary>
        /// <param name="expected">The DateTime that the current value is expected to be on or after.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOnOrAfter(DateTime expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s >= expected,
                DateTimeContractCodes.BeOnOrAfter,
                Subject.HasValue
                    ? $"Expected date and time to be on or after '{expected}' but found '{Subject}'"
                    : $"Expected date and time to be on or after '{expected}' but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime is neither on nor after the specified value.
        /// </summary>
        /// <param name="unexpected">The DateTime that the current value is expected not to be on nor after.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeOnOrAfter(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            return BeBefore(unexpected, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected year.
        /// </summary>
        /// <param name="expected">The expected year of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveYear(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Year == expected,
                DateTimeContractCodes.HaveYear,
                Subject.HasValue
                    ? $"Expected the year part of the date to be {expected} but found {Subject.Value.Year}"
                    : $"Expected the year part of the date to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Year ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected year.
        /// </summary>
        /// <param name="unexpected">The year that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveYear(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Year != unexpected,
                DateTimeContractCodes.NotHaveYear,
                Subject.HasValue
                    ? $"Did not expect the year part of the date to be {unexpected} but it was"
                    : $"Did not expect the year part of the date to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Year ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected month.
        /// </summary>
        /// <param name="expected">The expected month of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveMonth(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Month == expected,
                DateTimeContractCodes.HaveMonth,
                Subject.HasValue
                    ? $"Expected the month part of the date to be {expected} but found {Subject.Value.Month}"
                    : $"Expected the month part of the date to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Month ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected month.
        /// </summary>
        /// <param name="unexpected">The month that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveMonth(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Month != unexpected,
                DateTimeContractCodes.NotHaveMonth,
                Subject.HasValue
                    ? $"Did not expect the month part of the date to be {unexpected} but it was"
                    : $"Did not expect the month part of the date to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Month ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected day.
        /// </summary>
        /// <param name="expected">The expected day of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveDay(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Day == expected,
                DateTimeContractCodes.HaveDay,
                Subject.HasValue
                    ? $"Expected the day part of the date to be {expected} but found {Subject.Value.Day}"
                    : $"Expected the day part of the date to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Day ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected day.
        /// </summary>
        /// <param name="unexpected">The day that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveDay(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Day != unexpected,
                DateTimeContractCodes.NotHaveDay,
                Subject.HasValue
                    ? $"Did not expect the day part of the date to be {unexpected} but it was"
                    : $"Did not expect the day part of the date to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Day ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected hour.
        /// </summary>
        /// <param name="expected">The expected hour of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveHour(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Hour == expected,
                DateTimeContractCodes.HaveHour,
                Subject.HasValue
                    ? $"Expected the hour part of the time to be {expected} but found {Subject.Value.Hour}"
                    : $"Expected the hour part of the time to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Hour ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected hour.
        /// </summary>
        /// <param name="unexpected">The hour that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveHour(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Hour != unexpected,
                DateTimeContractCodes.NotHaveHour,
                Subject.HasValue
                    ? $"Did not expect the hour part of the time to be {unexpected} but it was"
                    : $"Did not expect the hour part of the time to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Hour ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected minute.
        /// </summary>
        /// <param name="expected">The expected minutes of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveMinute(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Minute == expected,
                DateTimeContractCodes.HaveMinute,
                Subject.HasValue
                    ? $"Expected the minute part of the time to be {expected} but found {Subject.Value.Minute}"
                    : $"Expected the minute part of the time to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Minute ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected minute.
        /// </summary>
        /// <param name="unexpected">The minute that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveMinute(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Minute != unexpected,
                DateTimeContractCodes.NotHaveMinute,
                Subject.HasValue
                    ? $"Did not expect the minute part of the time to be {unexpected} but it was"
                    : $"Did not expect the minute part of the time to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Minute ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected second.
        /// </summary>
        /// <param name="expected">The expected seconds of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveSecond(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Second == expected,
                DateTimeContractCodes.HaveSecond,
                Subject.HasValue
                    ? $"Expected the seconds part of the time to be {expected} but found {Subject.Value.Second}"
                    : $"Expected the seconds part of the time to be {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.Second ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected second.
        /// </summary>
        /// <param name="unexpected">The second that should not be in the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotHaveSecond(int unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Second != unexpected,
                DateTimeContractCodes.NotHaveSecond,
                Subject.HasValue
                    ? $"Did not expect the seconds part of the time to be {unexpected} but it was"
                    : $"Did not expect the seconds part of the time to be {unexpected} but found null",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject?.Second ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime has the expected date (ignoring time).
        /// </summary>
        /// <param name="expected">The expected date portion of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeSameDateAs(DateTime expected, string because = "", params object[] becauseArgs)
        {
            var expectedDate = expected.Date;
            return Assert(
                s => s.HasValue && s.Value.Date == expectedDate,
                DateTimeContractCodes.BeSameDateAs,
                Subject.HasValue
                    ? $"Expected the date part of the date and time to be '{expectedDate:d}' but found '{Subject.Value.Date:d}'"
                    : $"Expected the date part of the date and time to be '{expectedDate:d}' but found null",
                e => e.With("expected", expectedDate)
                      .With("actual", Subject?.Date.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current DateTime does not have the unexpected date (ignoring time).
        /// </summary>
        /// <param name="unexpected">The date that is not to match the date portion of the current value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeSameDateAs(DateTime unexpected, string because = "", params object[] becauseArgs)
        {
            var unexpectedDate = unexpected.Date;
            return Assert(
                s => s.HasValue && s.Value.Date != unexpectedDate,
                DateTimeContractCodes.NotBeSameDateAs,
                Subject.HasValue
                    ? $"Did not expect the date part of the date and time to be '{unexpectedDate:d}' but it was"
                    : $"Did not expect the date part of the date and time to be '{unexpectedDate:d}' but found null",
                e => e.With("unexpected", unexpectedDate)
                      .With("actual", Subject?.Date.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTime is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(params DateTime?[] validValues)
        {
            return BeOneOf(validValues, string.Empty);
        }

        /// <summary>
        /// Asserts that the DateTime is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(params DateTime[] validValues)
        {
            return BeOneOf(validValues.Cast<DateTime?>());
        }

        /// <summary>
        /// Asserts that the DateTime is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(IEnumerable<DateTime> validValues, string because = "", params object[] becauseArgs)
        {
            return BeOneOf(validValues.Cast<DateTime?>(), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the DateTime is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(IEnumerable<DateTime?> validValues, string because = "", params object[] becauseArgs)
        {
            var validList = validValues.ToList();
            return Assert(
                s => validList.Contains(s),
                DateTimeContractCodes.BeOneOf,
                $"Expected date and time to be one of [{string.Join(", ", validList.Select(v => v?.ToString() ?? "(null)"))}] but found '{Subject?.ToString() ?? "(null)"}'",
                e => e.With("validValues", string.Join(", ", validList.Select(v => v?.ToString() ?? "(null)")))
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the DateTime represents a value in the expected DateTimeKind.
        /// </summary>
        /// <param name="expectedKind">The expected DateTimeKind that the current value must represent.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeIn(DateTimeKind expectedKind, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value.Kind == expectedKind,
                DateTimeContractCodes.BeIn,
                Subject.HasValue
                    ? $"Expected the date and time to be in {expectedKind} but found {Subject.Value.Kind}"
                    : $"Expected the date and time to be in {expectedKind} but found null",
                e => e.With("expectedKind", expectedKind.ToString())
                      .With("actualKind", Subject?.Kind.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
