using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for enum assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class EnumAssertionsBase<TEnum, TSelf> : Assertions<TEnum?, TSelf>
        where TEnum : struct, Enum
        where TSelf : EnumAssertionsBase<TEnum, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumAssertionsBase{TEnum, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected EnumAssertionsBase(TEnum? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable enum is null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNull(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                EnumAssertionCodes.BeNull,
                $"Expected the enum to be null but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable enum is not null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeNull(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                EnumAssertionCodes.NotBeNull,
                "Expected the enum to have a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current enum is exactly equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(TEnum expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s?.Equals(expected) == true,
                EnumAssertionCodes.Be,
                Subject.HasValue
                    ? $"Expected the enum to be '{expected}' but found '{Subject}'"
                    : $"Expected the enum to be '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current enum is exactly equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(TEnum? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => Nullable.Equals(s, expected),
                EnumAssertionCodes.Be,
                $"Expected the enum to be '{expected?.ToString() ?? "(null)"}' but found '{Subject?.ToString() ?? "(null)"}'",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current enum is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(TEnum unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s?.Equals(unexpected) != true,
                EnumAssertionCodes.NotBe,
                $"Expected the enum not to be '{unexpected}' but it is",
                e => e.With("unexpected", unexpected.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current enum is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(TEnum? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !Nullable.Equals(s, unexpected),
                EnumAssertionCodes.NotBe,
                $"Expected the enum not to be '{unexpected?.ToString() ?? "(null)"}' but it is",
                e => e.With("unexpected", unexpected?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current value is defined in the enum.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeDefined(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && Enum.IsDefined(typeof(TEnum), s.Value),
                EnumAssertionCodes.BeDefined,
                Subject.HasValue
                    ? $"Expected the enum to be defined in {typeof(TEnum).Name} but it is not"
                    : $"Expected the enum to be defined in {typeof(TEnum).Name} but found null",
                e => e.With("enumType", typeof(TEnum).Name)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current value is not defined in the enum.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeDefined(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && !Enum.IsDefined(typeof(TEnum), s.Value),
                EnumAssertionCodes.NotBeDefined,
                Subject.HasValue
                    ? $"Did not expect the enum to be defined in {typeof(TEnum).Name} but it is"
                    : $"Did not expect the enum to be defined in {typeof(TEnum).Name} but found null",
                e => e.With("enumType", typeof(TEnum).Name)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum has the expected numeric value.
        /// </summary>
        /// <param name="expected">The expected numeric value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(decimal expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && GetValue(s.Value) == expected,
                EnumAssertionCodes.HaveValue,
                Subject.HasValue
                    ? $"Expected the enum to have value {expected} but found {GetValue(Subject.Value)}"
                    : $"Expected the enum to have value {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject.HasValue ? GetValue(Subject.Value) : -1m)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum does not have the unexpected numeric value.
        /// </summary>
        /// <param name="unexpected">The unexpected numeric value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(decimal unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !(s.HasValue && GetValue(s.Value) == unexpected),
                EnumAssertionCodes.NotHaveValue,
                $"Expected the enum to not have value {unexpected} but found {Subject}",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject.HasValue ? GetValue(Subject.Value) : -1m)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum has the same numeric value as the expected enum.
        /// </summary>
        /// <typeparam name="T">The type of the expected enum.</typeparam>
        /// <param name="expected">The expected enum value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveSameValueAs<T>(T expected, string because = "", params object[] becauseArgs)
            where T : struct, Enum
        {
            return Assert(
                s => s.HasValue && GetValue(s.Value) == GetValue(expected),
                EnumAssertionCodes.HaveSameValueAs,
                Subject.HasValue
                    ? $"Expected the enum to have same value as '{expected}' but found '{Subject}'"
                    : $"Expected the enum to have same value as '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum does not have the same numeric value as the unexpected enum.
        /// </summary>
        /// <typeparam name="T">The type of the unexpected enum.</typeparam>
        /// <param name="unexpected">The unexpected enum value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveSameValueAs<T>(T unexpected, string because = "", params object[] becauseArgs)
            where T : struct, Enum
        {
            return Assert(
                s => !(s.HasValue && GetValue(s.Value) == GetValue(unexpected)),
                EnumAssertionCodes.NotHaveSameValueAs,
                $"Expected the enum to not have same value as '{unexpected}' but found '{Subject}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum has the same name as the expected enum.
        /// </summary>
        /// <typeparam name="T">The type of the expected enum.</typeparam>
        /// <param name="expected">The expected enum value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveSameNameAs<T>(T expected, string because = "", params object[] becauseArgs)
            where T : struct, Enum
        {
            return Assert(
                s => s.HasValue && GetName(s.Value) == GetName(expected),
                EnumAssertionCodes.HaveSameNameAs,
                Subject.HasValue
                    ? $"Expected the enum to have same name as '{expected}' but found '{Subject}'"
                    : $"Expected the enum to have same name as '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum does not have the same name as the unexpected enum.
        /// </summary>
        /// <typeparam name="T">The type of the unexpected enum.</typeparam>
        /// <param name="unexpected">The unexpected enum value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveSameNameAs<T>(T unexpected, string because = "", params object[] becauseArgs)
            where T : struct, Enum
        {
            return Assert(
                s => !(s.HasValue && GetName(s.Value) == GetName(unexpected)),
                EnumAssertionCodes.NotHaveSameNameAs,
                $"Expected the enum to not have same name as '{unexpected}' but found '{Subject}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum has the expected flag.
        /// </summary>
        /// <param name="expectedFlag">The expected flag.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveFlag(TEnum expectedFlag, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s?.HasFlag(expectedFlag) == true,
                EnumAssertionCodes.HaveFlag,
                Subject.HasValue
                    ? $"Expected the enum to have flag '{expectedFlag}' but found '{Subject}'"
                    : $"Expected the enum to have flag '{expectedFlag}' but found null",
                e => e.With("expectedFlag", expectedFlag.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum does not have the unexpected flag.
        /// </summary>
        /// <param name="unexpectedFlag">The unexpected flag.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveFlag(TEnum unexpectedFlag, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s?.HasFlag(unexpectedFlag) != true,
                EnumAssertionCodes.NotHaveFlag,
                $"Expected the enum to not have flag '{unexpectedFlag}'",
                e => e.With("unexpectedFlag", unexpectedFlag.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum matches the predicate.
        /// </summary>
        /// <param name="predicate">The predicate which must be satisfied.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf Match(Func<TEnum?, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate), "Cannot match an enum against a null predicate.");
            }

            return Assert(
                s => predicate(s),
                EnumAssertionCodes.Match,
                $"Expected the enum to match the predicate but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the enum is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOneOf(params TEnum[] validValues)
        {
            return BeOneOf(validValues, string.Empty);
        }

        /// <summary>
        /// Asserts that the enum is one of the specified valid values.
        /// </summary>
        /// <param name="validValues">The values that are valid.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when validValues is null.</exception>
        /// <exception cref="ArgumentException">Thrown when validValues is empty.</exception>
        public TSelf BeOneOf(IEnumerable<TEnum> validValues, string because = "", params object[] becauseArgs)
        {
            if (validValues is null)
            {
                throw new ArgumentNullException(nameof(validValues), "Cannot assert that an enum is one of a null list of enums");
            }

            var validList = validValues.ToList();
            if (validList.Count == 0)
            {
                throw new ArgumentException("Cannot assert that an enum is one of an empty list of enums", nameof(validValues));
            }

            return Assert(
                s => s.HasValue && validList.Contains(s.Value),
                EnumAssertionCodes.BeOneOf,
                Subject.HasValue
                    ? $"Expected the enum to be one of [{string.Join(", ", validList)}] but found '{Subject}'"
                    : $"Expected the enum to be one of [{string.Join(", ", validList)}] but found null",
                e => e.With("validValues", string.Join(", ", validList))
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        private static decimal GetValue<T>(T enumValue)
            where T : struct, Enum
        {
            return Convert.ToDecimal(enumValue, CultureInfo.InvariantCulture);
        }

        private static string GetName<T>(T enumValue)
            where T : struct, Enum
        {
            return enumValue.ToString();
        }
    }
}
