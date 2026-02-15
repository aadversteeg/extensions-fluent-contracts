using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for DateTime values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class DateTimeContracts : DateTimeContractsBase<DateTimeContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeContracts"/> class.
        /// </summary>
        /// <param name="subject">The DateTime value to check.</param>
        public DateTimeContracts(DateTime? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<DateTime?, Error>(DateTimeContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(DateTimeContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
