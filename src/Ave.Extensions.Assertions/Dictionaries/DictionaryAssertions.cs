using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Dictionaries
{
    /// <summary>
    /// Contains assertion methods for dictionaries.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public sealed class DictionaryAssertions<TKey, TValue> : DictionaryAssertionsBase<TKey, TValue, DictionaryAssertions<TKey, TValue>>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryAssertions{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="subject">The dictionary to assert on.</param>
        public DictionaryAssertions(IDictionary<TKey, TValue>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IDictionary<TKey, TValue>?, Error>(DictionaryAssertions<TKey, TValue> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(DictionaryAssertions<TKey, TValue> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
