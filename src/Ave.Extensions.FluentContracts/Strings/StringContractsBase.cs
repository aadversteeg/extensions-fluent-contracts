using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for string contracts containing all contract methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class StringContractsBase<TSelf> : Contracts<string?, TSelf>
        where TSelf : StringContractsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringContractsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The string value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected StringContractsBase(string? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that a string is exactly the same as another string, including the casing and any leading or trailing whitespace.
        /// </summary>
        /// <param name="expected">The expected string.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf Be(
            string? expected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => string.Equals(s, expected, StringComparison.Ordinal),
                StringContractCodes.Be,
                $"Expected '{expected ?? "(null)"}' but found '{Subject ?? "(null)"}'",
                e => e.With("expected", expected ?? "(null)")
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is not exactly the same as the specified value.
        /// </summary>
        /// <param name="unexpected">The string that the subject is not expected to be.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBe(
            string? unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => !string.Equals(s, unexpected, StringComparison.Ordinal),
                StringContractCodes.NotBe,
                $"Did not expect '{unexpected ?? "(null)"}'",
                e => e.With("unexpected", unexpected ?? "(null)")
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeEmpty(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s?.Length == 0,
                StringContractCodes.BeEmpty,
                $"Expected empty string but found '{Subject ?? "(null)"}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is not empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeEmpty(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is null || s.Length > 0,
                StringContractCodes.NotBeEmpty,
                "Expected non-empty string but found empty string",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is either null or empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeNullOrEmpty(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => string.IsNullOrEmpty(s),
                StringContractCodes.BeNullOrEmpty,
                $"Expected null or empty string but found '{Subject}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is neither null nor empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeNullOrEmpty(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => !string.IsNullOrEmpty(s),
                StringContractCodes.NotBeNullOrEmpty,
                $"Expected non-null and non-empty string but found '{Subject ?? "(null)"}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is either null, empty, or consists only of whitespace.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeNullOrWhiteSpace(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => string.IsNullOrWhiteSpace(s),
                StringContractCodes.BeNullOrWhiteSpace,
                $"Expected null or whitespace string but found '{Subject}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string is neither null, empty, nor consists only of whitespace.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeNullOrWhiteSpace(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => !string.IsNullOrWhiteSpace(s),
                StringContractCodes.NotBeNullOrWhiteSpace,
                $"Expected non-null and non-whitespace string but found '{Subject ?? "(null)"}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string has the specified length.
        /// </summary>
        /// <param name="expected">The expected length of the string.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveLength(
            int expected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Length == expected,
                StringContractCodes.HaveLength,
                Subject is null
                    ? $"Expected string with length {expected} but found null"
                    : $"Expected string with length {expected} but found length {Subject.Length}",
                e => e.With("expectedLength", expected)
                      .With("actualLength", Subject?.Length ?? -1)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string starts exactly with the specified value.
        /// </summary>
        /// <param name="expected">The string that the subject is expected to start with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf StartWith(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected), "Cannot compare start of string with <null>.");
            }

            return Assert(
                s => s is not null && s.StartsWith(expected, StringComparison.Ordinal),
                StringContractCodes.StartWith,
                Subject is null
                    ? $"Expected string starting with '{expected}' but found null"
                    : $"Expected string starting with '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string does not start with the specified value.
        /// </summary>
        /// <param name="unexpected">The string that the subject is not expected to start with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unexpected is null.</exception>
        public TSelf NotStartWith(
            string unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            if (unexpected is null)
            {
                throw new ArgumentNullException(nameof(unexpected), "Cannot compare start of string with <null>.");
            }

            return Assert(
                s => s is null || !s.StartsWith(unexpected, StringComparison.Ordinal),
                StringContractCodes.NotStartWith,
                $"Did not expect string to start with '{unexpected}'",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string ends exactly with the specified value.
        /// </summary>
        /// <param name="expected">The string that the subject is expected to end with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf EndWith(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected), "Cannot compare end of string with <null>.");
            }

            return Assert(
                s => s is not null && s.EndsWith(expected, StringComparison.Ordinal),
                StringContractCodes.EndWith,
                Subject is null
                    ? $"Expected string ending with '{expected}' but found null"
                    : $"Expected string ending with '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string does not end with the specified value.
        /// </summary>
        /// <param name="unexpected">The string that the subject is not expected to end with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unexpected is null.</exception>
        public TSelf NotEndWith(
            string unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            if (unexpected is null)
            {
                throw new ArgumentNullException(nameof(unexpected), "Cannot compare end of string with <null>.");
            }

            return Assert(
                s => s is null || !s.EndsWith(unexpected, StringComparison.Ordinal),
                StringContractCodes.NotEndWith,
                $"Did not expect string to end with '{unexpected}'",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string contains another string.
        /// </summary>
        /// <param name="expected">The string that the subject is expected to contain.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        /// <exception cref="ArgumentException">Thrown when expected is empty.</exception>
        public TSelf Contain(
            string expected,
            string because = "",
            params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected), "Cannot assert string containment against <null>.");
            }

            if (expected.Length == 0)
            {
                throw new ArgumentException("Cannot assert string containment against an empty string.", nameof(expected));
            }

            return Assert(
                s => s is not null && s.Contains(expected),
                StringContractCodes.Contain,
                Subject is null
                    ? $"Expected string containing '{expected}' but found null"
                    : $"Expected string containing '{expected}' but found '{Subject}'",
                e => e.With("expected", expected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string does not contain another string.
        /// </summary>
        /// <param name="unexpected">The string that the subject is not expected to contain.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unexpected is null.</exception>
        /// <exception cref="ArgumentException">Thrown when unexpected is empty.</exception>
        public TSelf NotContain(
            string unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            if (unexpected is null)
            {
                throw new ArgumentNullException(nameof(unexpected), "Cannot assert string containment against <null>.");
            }

            if (unexpected.Length == 0)
            {
                throw new ArgumentException("Cannot assert string containment against an empty string.", nameof(unexpected));
            }

            return Assert(
                s => s is null || !s.Contains(unexpected),
                StringContractCodes.NotContain,
                $"Did not expect string to contain '{unexpected}'",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string matches a regular expression pattern.
        /// </summary>
        /// <param name="regularExpression">The regular expression pattern to match.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when regularExpression is null.</exception>
        public TSelf MatchRegex(
            string regularExpression,
            string because = "",
            params object[] becauseArgs)
        {
            if (regularExpression is null)
            {
                throw new ArgumentNullException(nameof(regularExpression), "Cannot match string against <null>.");
            }

            return Assert(
                s => s is not null && Regex.IsMatch(s, regularExpression),
                StringContractCodes.MatchRegex,
                Subject is null
                    ? $"Expected string matching regex '{regularExpression}' but found null"
                    : $"Expected string matching regex '{regularExpression}' but found '{Subject}'",
                e => e.With("pattern", regularExpression)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string matches a regular expression.
        /// </summary>
        /// <param name="regularExpression">The regular expression to match.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when regularExpression is null.</exception>
        public TSelf MatchRegex(
            Regex regularExpression,
            string because = "",
            params object[] becauseArgs)
        {
            if (regularExpression is null)
            {
                throw new ArgumentNullException(nameof(regularExpression), "Cannot match string against <null>.");
            }

            return Assert(
                s => s is not null && regularExpression.IsMatch(s),
                StringContractCodes.MatchRegex,
                Subject is null
                    ? $"Expected string matching regex '{regularExpression}' but found null"
                    : $"Expected string matching regex '{regularExpression}' but found '{Subject}'",
                e => e.With("pattern", regularExpression.ToString())
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string does not match a regular expression pattern.
        /// </summary>
        /// <param name="regularExpression">The regular expression pattern to not match.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when regularExpression is null.</exception>
        public TSelf NotMatchRegex(
            string regularExpression,
            string because = "",
            params object[] becauseArgs)
        {
            if (regularExpression is null)
            {
                throw new ArgumentNullException(nameof(regularExpression), "Cannot match string against <null>.");
            }

            return Assert(
                s => s is null || !Regex.IsMatch(s, regularExpression),
                StringContractCodes.NotMatchRegex,
                $"Did not expect string to match regex '{regularExpression}'",
                e => e.With("pattern", regularExpression)
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that a string does not match a regular expression.
        /// </summary>
        /// <param name="regularExpression">The regular expression to not match.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when regularExpression is null.</exception>
        public TSelf NotMatchRegex(
            Regex regularExpression,
            string because = "",
            params object[] becauseArgs)
        {
            if (regularExpression is null)
            {
                throw new ArgumentNullException(nameof(regularExpression), "Cannot match string against <null>.");
            }

            return Assert(
                s => s is null || !regularExpression.IsMatch(s),
                StringContractCodes.NotMatchRegex,
                $"Did not expect string to match regex '{regularExpression}'",
                e => e.With("pattern", regularExpression.ToString())
                      .With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that all characters in a string are in upper casing.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeUpperCased(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.All(char.IsUpper),
                StringContractCodes.BeUpperCased,
                $"Expected all characters to be upper cased but found '{Subject ?? "(null)"}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that all characters in a string are in lower casing.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeLowerCased(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.All(char.IsLower),
                StringContractCodes.BeLowerCased,
                $"Expected all characters to be lower cased but found '{Subject ?? "(null)"}'",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that not all characters in a string are in upper casing.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeUpperCased(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is null || s.Any(ch => !char.IsUpper(ch)),
                StringContractCodes.NotBeUpperCased,
                "Did not expect all characters to be upper cased",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that not all characters in a string are in lower casing.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeLowerCased(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is null || s.Any(ch => !char.IsLower(ch)),
                StringContractCodes.NotBeLowerCased,
                "Did not expect all characters to be lower cased",
                e => e.With("actual", Subject ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
