using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for Exception values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TException">The type of exception.</typeparam>
    public sealed class MustExceptionContracts<TException> : ExceptionContractsBase<TException, MustExceptionContracts<TException>>
        where TException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustExceptionContracts{TException}"/> class.
        /// </summary>
        /// <param name="exception">The exception to check.</param>
        public MustExceptionContracts(TException? exception) : base(exception, throwOnFailure: true)
        {
        }
    }
}
