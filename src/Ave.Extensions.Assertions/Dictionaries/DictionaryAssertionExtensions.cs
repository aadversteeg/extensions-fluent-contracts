using System.Collections.Generic;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for dictionary types.
    /// </summary>
    public static class DictionaryAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="DictionaryAssertions{TKey, TValue}"/> object for asserting on the specified dictionary.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to assert on.</param>
        /// <returns>A <see cref="DictionaryAssertions{TKey, TValue}"/> instance.</returns>
        public static DictionaryAssertions<TKey, TValue> Should<TKey, TValue>(this IDictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new DictionaryAssertions<TKey, TValue>(subject);
        }

        /// <summary>
        /// Returns a <see cref="DictionaryAssertions{TKey, TValue}"/> object for asserting on the specified dictionary.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to assert on.</param>
        /// <returns>A <see cref="DictionaryAssertions{TKey, TValue}"/> instance.</returns>
        public static DictionaryAssertions<TKey, TValue> Should<TKey, TValue>(this Dictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new DictionaryAssertions<TKey, TValue>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDictionaryAssertions{TKey, TValue}"/> object for asserting on the specified dictionary.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to assert on.</param>
        /// <returns>A <see cref="MustDictionaryAssertions{TKey, TValue}"/> instance.</returns>
        public static MustDictionaryAssertions<TKey, TValue> Must<TKey, TValue>(this IDictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new MustDictionaryAssertions<TKey, TValue>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDictionaryAssertions{TKey, TValue}"/> object for asserting on the specified dictionary.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to assert on.</param>
        /// <returns>A <see cref="MustDictionaryAssertions{TKey, TValue}"/> instance.</returns>
        public static MustDictionaryAssertions<TKey, TValue> Must<TKey, TValue>(this Dictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new MustDictionaryAssertions<TKey, TValue>(subject);
        }
    }
}
