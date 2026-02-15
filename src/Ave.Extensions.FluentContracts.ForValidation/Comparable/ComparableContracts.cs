using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for IComparable{T} values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The comparable type.</typeparam>
    public sealed class ComparableContracts<T> : ComparableContractsBase<T, ComparableContracts<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The value to check.</param>
        public ComparableContracts(T subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<T, Error>(ComparableContracts<T> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ComparableContracts<T> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
