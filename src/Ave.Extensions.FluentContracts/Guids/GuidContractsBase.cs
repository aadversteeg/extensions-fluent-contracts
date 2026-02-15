using System;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for Guid contracts containing all contract methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class GuidContractsBase<TSelf> : Contracts<Guid, TSelf>
        where TSelf : GuidContractsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidContractsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The Guid value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected GuidContractsBase(Guid subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the Guid is <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == Guid.Empty,
                GuidContractCodes.BeEmpty,
                $"Expected Guid to be empty but found '{Subject}'",
                e => e.With("actual", Subject.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is not <see cref="Guid.Empty"/>.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != Guid.Empty,
                GuidContractCodes.NotBeEmpty,
                "Did not expect Guid to be empty",
                e => e.With("actual", Subject.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is equal to the expected GUID.
        /// </summary>
        /// <param name="expected">The expected string value to compare the actual value with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
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
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf Be(Guid expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                GuidContractCodes.Be,
                $"Expected Guid to be '{expected}' but found '{Subject}'",
                e => e.With("expected", expected.ToString())
                      .With("actual", Subject.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the Guid is not equal to the unexpected GUID.
        /// </summary>
        /// <param name="unexpected">The unexpected string value to compare the actual value with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
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
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBe(Guid unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                GuidContractCodes.NotBe,
                $"Did not expect Guid to be '{unexpected}'",
                e => e.With("unexpected", unexpected.ToString())
                      .With("actual", Subject.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
