using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for numeric values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class NumericContracts<T> : NumericContractsBase<T, NumericContracts<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NumericContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The numeric value to check.</param>
        public NumericContracts(T subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<T, Error>(NumericContracts<T> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(NumericContracts<T> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
