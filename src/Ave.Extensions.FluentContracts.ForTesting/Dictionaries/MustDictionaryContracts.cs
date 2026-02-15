using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for dictionaries.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public sealed class MustDictionaryContracts<TKey, TValue> : DictionaryContractsBase<TKey, TValue, MustDictionaryContracts<TKey, TValue>>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDictionaryContracts{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="subject">The dictionary to check.</param>
        public MustDictionaryContracts(IDictionary<TKey, TValue>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
