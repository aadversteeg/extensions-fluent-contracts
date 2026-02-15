using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for dictionary types.
    /// </summary>
    public static class DictionaryContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="DictionaryContracts{TKey, TValue}"/> object for checking contracts on the specified dictionary.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to check.</param>
        /// <returns>A <see cref="DictionaryContracts{TKey, TValue}"/> instance.</returns>
        public static DictionaryContracts<TKey, TValue> Should<TKey, TValue>(this IDictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new DictionaryContracts<TKey, TValue>(subject);
        }

        /// <summary>
        /// Returns a <see cref="DictionaryContracts{TKey, TValue}"/> object for checking contracts on the specified dictionary.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to check.</param>
        /// <returns>A <see cref="DictionaryContracts{TKey, TValue}"/> instance.</returns>
        public static DictionaryContracts<TKey, TValue> Should<TKey, TValue>(this Dictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new DictionaryContracts<TKey, TValue>(subject);
        }
    }
}
