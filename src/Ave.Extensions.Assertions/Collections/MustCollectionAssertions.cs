using System.Collections.Generic;

namespace Ave.Extensions.Assertions.Collections
{
    /// <summary>
    /// Contains assertion methods for collections that throw on failure.
    /// Use Must() extension method to create instances.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public sealed class MustCollectionAssertions<T> : CollectionAssertionsBase<T, MustCollectionAssertions<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustCollectionAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The collection to assert on.</param>
        public MustCollectionAssertions(IEnumerable<T>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
