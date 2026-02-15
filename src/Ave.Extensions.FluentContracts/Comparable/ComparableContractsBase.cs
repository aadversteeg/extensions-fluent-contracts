using System;
using System.Linq;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class containing contract methods for IComparable{T} values.
    /// </summary>
    /// <typeparam name="T">The comparable type.</typeparam>
    /// <typeparam name="TSelf">The concrete contract type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class ComparableContractsBase<T, TSelf> : Contracts<T, TSelf>
        where T : IComparable<T>
        where TSelf : ComparableContractsBase<T, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableContractsBase{T, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure instead of recording it.</param>
        protected ComparableContractsBase(T subject, bool throwOnFailure) : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the value is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf Be(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) == 0,
                ComparableContractCodes.Be,
                Subject != null
                    ? $"Expected value to be '{expected}' but found '{Subject}'"
                    : $"Expected value to be '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBe(T unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == null || s.CompareTo(unexpected) != 0,
                ComparableContractCodes.NotBe,
                $"Did not expect value to be '{unexpected}'",
                e => e.With("unexpected", unexpected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value compares equal to the expected value using CompareTo.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeRankedEquallyTo(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) == 0,
                ComparableContractCodes.BeRankedEquallyTo,
                Subject != null
                    ? $"Expected value to be ranked equally to '{expected}' but found '{Subject}'"
                    : $"Expected value to be ranked equally to '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value does not compare equal to the unexpected value using CompareTo.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeRankedEquallyTo(T unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == null || s.CompareTo(unexpected) != 0,
                ComparableContractCodes.NotBeRankedEquallyTo,
                $"Did not expect value to be ranked equally to '{unexpected}'",
                e => e.With("unexpected", unexpected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is greater than the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeGreaterThan(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) > 0,
                ComparableContractCodes.BeGreaterThan,
                Subject != null
                    ? $"Expected value to be greater than '{expected}' but found '{Subject}'"
                    : $"Expected value to be greater than '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is greater than or equal to the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeGreaterThanOrEqualTo(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) >= 0,
                ComparableContractCodes.BeGreaterThanOrEqualTo,
                Subject != null
                    ? $"Expected value to be greater than or equal to '{expected}' but found '{Subject}'"
                    : $"Expected value to be greater than or equal to '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is less than the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeLessThan(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) < 0,
                ComparableContractCodes.BeLessThan,
                Subject != null
                    ? $"Expected value to be less than '{expected}' but found '{Subject}'"
                    : $"Expected value to be less than '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is less than or equal to the expected value.
        /// </summary>
        /// <param name="expected">The value to compare with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeLessThanOrEqualTo(T expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(expected) <= 0,
                ComparableContractCodes.BeLessThanOrEqualTo,
                Subject != null
                    ? $"Expected value to be less than or equal to '{expected}' but found '{Subject}'"
                    : $"Expected value to be less than or equal to '{expected}' but found null",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is within a specified range (inclusive).
        /// </summary>
        /// <param name="minimum">The minimum value (inclusive).</param>
        /// <param name="maximum">The maximum value (inclusive).</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeInRange(T minimum, T maximum, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != null && s.CompareTo(minimum) >= 0 && s.CompareTo(maximum) <= 0,
                ComparableContractCodes.BeInRange,
                Subject != null
                    ? $"Expected value to be in range [{minimum}..{maximum}] but found '{Subject}'"
                    : $"Expected value to be in range [{minimum}..{maximum}] but found null",
                e => e.With("minimum", minimum?.ToString() ?? "(null)")
                      .With("maximum", maximum?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is not within a specified range (inclusive).
        /// </summary>
        /// <param name="minimum">The minimum value (inclusive).</param>
        /// <param name="maximum">The maximum value (inclusive).</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeInRange(T minimum, T maximum, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == null || s.CompareTo(minimum) < 0 || s.CompareTo(maximum) > 0,
                ComparableContractCodes.NotBeInRange,
                $"Did not expect value '{Subject}' to be in range [{minimum}..{maximum}]",
                e => e.With("minimum", minimum?.ToString() ?? "(null)")
                      .With("maximum", maximum?.ToString() ?? "(null)")
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is one of the specified expected values.
        /// </summary>
        /// <param name="validValues">The valid values.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(params T[] validValues)
        {
            return BeOneOf(validValues, "", Array.Empty<object>());
        }

        /// <summary>
        /// Asserts that the value is one of the specified expected values.
        /// </summary>
        /// <param name="validValues">The valid values.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeOneOf(T[] validValues, string because, params object[] becauseArgs)
        {
            var validValuesStr = string.Join(", ", validValues.Select(v => v?.ToString() ?? "(null)"));
            return Assert(
                s => s != null && validValues.Any(v => s.CompareTo(v) == 0),
                ComparableContractCodes.BeOneOf,
                Subject != null
                    ? $"Expected value to be one of [{validValuesStr}] but found '{Subject}'"
                    : $"Expected value to be one of [{validValuesStr}] but found null",
                e => e.With("validValues", validValuesStr)
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
