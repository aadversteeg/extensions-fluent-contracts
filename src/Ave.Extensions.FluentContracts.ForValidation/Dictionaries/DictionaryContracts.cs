using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for dictionaries.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public sealed class DictionaryContracts<TKey, TValue> : DictionaryContractsBase<TKey, TValue, DictionaryContracts<TKey, TValue>>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryContracts{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="subject">The dictionary to check.</param>
        public DictionaryContracts(IDictionary<TKey, TValue>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IDictionary<TKey, TValue>?, Error>(DictionaryContracts<TKey, TValue> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(DictionaryContracts<TKey, TValue> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
