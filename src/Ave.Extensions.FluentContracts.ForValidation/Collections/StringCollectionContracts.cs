using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for string collections. Returns Result types on implicit conversion.
    /// Use Should() extension method to create instances.
    /// </summary>
    public sealed class StringCollectionContracts : StringCollectionContractsBase<StringCollectionContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringCollectionContracts"/> class.
        /// </summary>
        /// <param name="subject">The string collection to check.</param>
        public StringCollectionContracts(IEnumerable<string?>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IEnumerable<string?>?, Error>(StringCollectionContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(StringCollectionContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
