using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for dictionary types.
    /// </summary>
    public static class MustDictionaryContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustDictionaryContracts{TKey, TValue}"/> object for checking contracts on the specified dictionary.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="subject">The dictionary to check.</param>
        /// <returns>A <see cref="MustDictionaryContracts{TKey, TValue}"/> instance.</returns>
        public static MustDictionaryContracts<TKey, TValue> Must<TKey, TValue>(this IDictionary<TKey, TValue>? subject)
            where TKey : notnull
        {
            return new MustDictionaryContracts<TKey, TValue>(subject);
        }
    }
}
