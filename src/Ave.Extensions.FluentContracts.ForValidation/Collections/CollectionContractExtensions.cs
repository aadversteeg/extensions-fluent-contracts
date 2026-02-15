using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for collection types.
    /// </summary>
    public static class CollectionContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="CollectionContracts{T}"/> object for checking contracts on the specified collection.
        /// Failures are recorded and can be converted to Result types.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="subject">The collection to check.</param>
        /// <returns>A <see cref="CollectionContracts{T}"/> instance.</returns>
        public static CollectionContracts<T> Should<T>(this IEnumerable<T>? subject)
        {
            return new CollectionContracts<T>(subject);
        }

        /// <summary>
        /// Returns a <see cref="StringCollectionContracts"/> object for checking contracts on the specified string collection.
        /// Failures are recorded and can be converted to Result types.
        /// </summary>
        /// <param name="subject">The string collection to check.</param>
        /// <returns>A <see cref="StringCollectionContracts"/> instance.</returns>
        public static StringCollectionContracts Should(this IEnumerable<string?>? subject)
        {
            return new StringCollectionContracts(subject);
        }
    }
}
