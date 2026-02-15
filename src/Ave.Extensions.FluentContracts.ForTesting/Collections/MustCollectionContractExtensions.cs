using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for collection types.
    /// </summary>
    public static class MustCollectionContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustCollectionContracts{T}"/> object for checking contracts on the specified collection.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="subject">The collection to check.</param>
        /// <returns>A <see cref="MustCollectionContracts{T}"/> instance.</returns>
        public static MustCollectionContracts<T> Must<T>(this IEnumerable<T>? subject)
        {
            return new MustCollectionContracts<T>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustStringCollectionContracts"/> object for checking contracts on the specified string collection.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The string collection to check.</param>
        /// <returns>A <see cref="MustStringCollectionContracts"/> instance.</returns>
        public static MustStringCollectionContracts Must(this IEnumerable<string?>? subject)
        {
            return new MustStringCollectionContracts(subject);
        }
    }
}
