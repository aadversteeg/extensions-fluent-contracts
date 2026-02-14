using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Functions
{
    /// <summary>
    /// Contains assertion methods for Func{T} delegates.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    public sealed class FunctionAssertions<T> : FunctionAssertionsBase<T, FunctionAssertions<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionAssertions{T}"/> class.
        /// </summary>
        /// <param name="func">The function to assert on.</param>
        public FunctionAssertions(Func<T> func) : base(func, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Func<T>, Error>(FunctionAssertions<T> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(FunctionAssertions<T> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
