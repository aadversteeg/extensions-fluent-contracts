using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for Exception values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="TException">The type of exception.</typeparam>
    public sealed class ExceptionAssertions<TException> : ExceptionAssertionsBase<TException, ExceptionAssertions<TException>>
        where TException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertions{TException}"/> class.
        /// </summary>
        /// <param name="exception">The exception to assert on.</param>
        public ExceptionAssertions(TException? exception) : base(exception, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<TException?, Error>(ExceptionAssertions<TException> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ExceptionAssertions<TException> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
