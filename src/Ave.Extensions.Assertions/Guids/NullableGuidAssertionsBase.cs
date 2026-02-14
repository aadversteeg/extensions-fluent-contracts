using System;

namespace Ave.Extensions.Assertions.Guids
{
    /// <summary>
    /// Base class for nullable Guid assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class NullableGuidAssertionsBase<TSelf> : Assertions<Guid?, TSelf>
        where TSelf : NullableGuidAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableGuidAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The nullable Guid value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected NullableGuidAssertionsBase(Guid? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable Guid has a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                GuidAssertionCodes.HaveValue,
                "Expected Guid to have a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable Guid does not have a value (is null).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                GuidAssertionCodes.NotHaveValue,
                $"Did not expect Guid to have a value but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable Guid is null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNull(string because = "", params object[] becauseArgs)
        {
            return NotHaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the nullable Guid is not null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeNull(string because = "", params object[] becauseArgs)
        {
            return HaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the Guid is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == Guid.Empty,
                GuidAssertionCodes.BeEmpty,
                $"Expected Guid to be empty but found '{Subject}'",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is not <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && s.Value != Guid.Empty,
                GuidAssertionCodes.NotBeEmpty,
                Subject.HasValue
                    ? "Did not expect Guid to be empty"
                    : "Did not expect Guid to be empty but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is equal to the expected GUID.
        /// </summary>
        /// <param name="expected">The expected string value to compare the actual value with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentException">The format of expected is invalid.</exception>
        public TSelf Be(string expected, string because = "", params object[] becauseArgs)
        {
            if (!Guid.TryParse(expected, out Guid expectedGuid))
            {
                throw new ArgumentException($"Unable to parse \"{expected}\" as a valid GUID", nameof(expected));
            }

            return Be(expectedGuid, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the Guid is equal to the expected GUID.
        /// </summary>
        /// <param name="expected">The expected value to compare the actual value with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(Guid expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                GuidAssertionCodes.Be,
                Subject.HasValue
                    ? $"Expected Guid to be '{expected}' but found '{Subject}'"
                    : $"Expected Guid to be '{expected}' but found null",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is not equal to the unexpected GUID.
        /// </summary>
        /// <param name="unexpected">The unexpected string value to compare the actual value with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentException">The format of unexpected is invalid.</exception>
        public TSelf NotBe(string unexpected, string because = "", params object[] becauseArgs)
        {
            if (!Guid.TryParse(unexpected, out Guid unexpectedGuid))
            {
                throw new ArgumentException($"Unable to parse \"{unexpected}\" as a valid GUID", nameof(unexpected));
            }

            return NotBe(unexpectedGuid, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the Guid is not equal to the unexpected GUID.
        /// </summary>
        /// <param name="unexpected">The unexpected value to compare the actual value with.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(Guid unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                GuidAssertionCodes.NotBe,
                $"Did not expect Guid to be '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
