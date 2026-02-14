using System;

namespace Ave.Extensions.Assertions.Exceptions
{
    /// <summary>
    /// Contains assertion methods for Exception values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TException">The type of exception.</typeparam>
    public sealed class MustExceptionAssertions<TException> : ExceptionAssertionsBase<TException, MustExceptionAssertions<TException>>
        where TException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustExceptionAssertions{TException}"/> class.
        /// </summary>
        /// <param name="exception">The exception to assert on.</param>
        public MustExceptionAssertions(TException? exception) : base(exception, throwOnFailure: true)
        {
        }
    }
}
