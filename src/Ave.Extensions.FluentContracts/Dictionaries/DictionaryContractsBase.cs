using System;
using System.Collections.Generic;
using System.Linq;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class containing contract methods for dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <typeparam name="TSelf">The concrete contract type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class DictionaryContractsBase<TKey, TValue, TSelf> : Contracts<IDictionary<TKey, TValue>?, TSelf>
        where TKey : notnull
        where TSelf : DictionaryContractsBase<TKey, TValue, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryContractsBase{TKey, TValue, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The dictionary to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure instead of recording it.</param>
        protected DictionaryContractsBase(IDictionary<TKey, TValue>? subject, bool throwOnFailure) : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the dictionary is null.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeNull(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null,
                DictionaryContractCodes.BeNull,
                $"Expected dictionary to be null but found dictionary with {Subject?.Count ?? 0} element(s)",
                e => e.With("actualCount", Subject?.Count ?? 0)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary is not null.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeNull(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null,
                DictionaryContractCodes.NotBeNull,
                "Expected dictionary not to be null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary is empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf BeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count == 0,
                DictionaryContractCodes.BeEmpty,
                Subject is null
                    ? "Expected empty dictionary but found null"
                    : $"Expected empty dictionary but found {Subject.Count} element(s)",
                e => e.With("actualCount", Subject?.Count ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary is not empty.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotBeEmpty(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count > 0,
                DictionaryContractCodes.NotBeEmpty,
                Subject is null
                    ? "Expected non-empty dictionary but found null"
                    : "Expected non-empty dictionary but found empty dictionary",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary has the expected count.
        /// </summary>
        /// <param name="expected">The expected count.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveCount(int expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Count == expected,
                DictionaryContractCodes.HaveCount,
                Subject is null
                    ? $"Expected dictionary with {expected} element(s) but found null"
                    : $"Expected dictionary with {expected} element(s) but found {Subject.Count} element(s)",
                e => e.With("expectedCount", expected)
                      .With("actualCount", Subject?.Count ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary contains the specified key.
        /// </summary>
        /// <param name="key">The key to find.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf ContainKey(TKey key, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.ContainsKey(key),
                DictionaryContractCodes.ContainKey,
                Subject is null
                    ? $"Expected dictionary to contain key '{key}' but found null"
                    : $"Expected dictionary to contain key '{key}' but it was not found",
                e => e.With("key", key?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary does not contain the specified key.
        /// </summary>
        /// <param name="key">The key that should not be present.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotContainKey(TKey key, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.ContainsKey(key),
                DictionaryContractCodes.NotContainKey,
                $"Did not expect dictionary to contain key '{key}' but it was found",
                e => e.With("key", key?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary contains all specified keys.
        /// </summary>
        /// <param name="keys">The keys to find.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf ContainKeys(params TKey[] keys)
        {
            return ContainKeys(keys, "", Array.Empty<object>());
        }

        /// <summary>
        /// Asserts that the dictionary contains all specified keys.
        /// </summary>
        /// <param name="keys">The keys to find.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf ContainKeys(TKey[] keys, string because, params object[] becauseArgs)
        {
            var keysStr = string.Join(", ", keys.Select(k => k?.ToString() ?? "(null)"));
            return Assert(
                s => s is not null && keys.All(k => s.ContainsKey(k)),
                DictionaryContractCodes.ContainKeys,
                Subject is null
                    ? $"Expected dictionary to contain keys [{keysStr}] but found null"
                    : $"Expected dictionary to contain keys [{keysStr}] but not all were found",
                e => e.With("keys", keysStr)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary contains the specified value.
        /// </summary>
        /// <param name="value">The value to find.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf ContainValue(TValue value, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Values.Contains(value),
                DictionaryContractCodes.ContainValue,
                Subject is null
                    ? $"Expected dictionary to contain value '{value}' but found null"
                    : $"Expected dictionary to contain value '{value}' but it was not found",
                e => e.With("value", value?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary does not contain the specified value.
        /// </summary>
        /// <param name="value">The value that should not be present.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotContainValue(TValue value, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.Values.Contains(value),
                DictionaryContractCodes.NotContainValue,
                $"Did not expect dictionary to contain value '{value}' but it was found",
                e => e.With("value", value?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary contains the specified key-value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The expected value for the key.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf ContainKeyValuePair(TKey key, TValue value, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.TryGetValue(key, out var actualValue) && Equals(actualValue, value),
                DictionaryContractCodes.ContainKeyValuePair,
                Subject is null
                    ? $"Expected dictionary to contain key-value pair [{key}={value}] but found null"
                    : Subject.TryGetValue(key, out var actual)
                        ? $"Expected dictionary to contain key-value pair [{key}={value}] but found value '{actual}' for key '{key}'"
                        : $"Expected dictionary to contain key-value pair [{key}={value}] but key '{key}' was not found",
                e => e.With("key", key?.ToString() ?? "(null)")
                      .With("expectedValue", value?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary does not contain the specified key-value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value that should not be associated with the key.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf NotContainKeyValuePair(TKey key, TValue value, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || !s.TryGetValue(key, out var actualValue) || !Equals(actualValue, value),
                DictionaryContractCodes.NotContainKeyValuePair,
                $"Did not expect dictionary to contain key-value pair [{key}={value}]",
                e => e.With("key", key?.ToString() ?? "(null)")
                      .With("unexpectedValue", value?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the dictionary has the same count as another collection.
        /// </summary>
        /// <typeparam name="TOther">The type of the other collection.</typeparam>
        /// <param name="other">The collection to compare count with.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf HaveSameCount<TOther>(IEnumerable<TOther> other, string because = "", params object[] becauseArgs)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            var otherCount = other.Count();
            return Assert(
                s => s is not null && s.Count == otherCount,
                DictionaryContractCodes.HaveSameCount,
                Subject is null
                    ? $"Expected dictionary to have same count as collection ({otherCount}) but found null"
                    : $"Expected dictionary to have same count as collection ({otherCount}) but found {Subject.Count} element(s)",
                e => e.With("expectedCount", otherCount)
                      .With("actualCount", Subject?.Count ?? -1)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
