using System.Collections.Generic;

namespace Ave.Extensions.Assertions.Dictionaries
{
    /// <summary>
    /// Contains assertion methods for dictionaries.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    public sealed class MustDictionaryAssertions<TKey, TValue> : DictionaryAssertionsBase<TKey, TValue, MustDictionaryAssertions<TKey, TValue>>
        where TKey : notnull
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDictionaryAssertions{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="subject">The dictionary to assert on.</param>
        public MustDictionaryAssertions(IDictionary<TKey, TValue>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
