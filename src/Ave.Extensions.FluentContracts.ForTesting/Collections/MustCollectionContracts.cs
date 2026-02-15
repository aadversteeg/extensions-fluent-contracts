using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for collections.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public sealed class MustCollectionContracts<T> : CollectionContractsBase<T, MustCollectionContracts<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustCollectionContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The collection to check.</param>
        public MustCollectionContracts(IEnumerable<T>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
