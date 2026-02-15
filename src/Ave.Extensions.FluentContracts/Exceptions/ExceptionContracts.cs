using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Contains contract methods for Exception values (core implementation).
    /// </summary>
    /// <typeparam name="TException">The type of exception.</typeparam>
    public class ExceptionContracts<TException> : ExceptionContractsBase<TException, ExceptionContracts<TException>>
        where TException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionContracts{TException}"/> class.
        /// </summary>
        /// <param name="exception">The exception to check.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure instead of recording it.</param>
        public ExceptionContracts(TException? exception, bool throwOnFailure = false) : base(exception, throwOnFailure)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<TException?, Error>(ExceptionContracts<TException> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ExceptionContracts<TException> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
