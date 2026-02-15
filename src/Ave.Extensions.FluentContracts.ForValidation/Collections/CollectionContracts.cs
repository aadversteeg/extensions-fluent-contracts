using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for collections. Returns Result types on implicit conversion.
    /// Use Should() extension method to create instances.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public sealed class CollectionContracts<T> : CollectionContractsBase<T, CollectionContracts<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The collection to check.</param>
        public CollectionContracts(IEnumerable<T>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IEnumerable<T>?, Error>(CollectionContracts<T> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(CollectionContracts<T> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
