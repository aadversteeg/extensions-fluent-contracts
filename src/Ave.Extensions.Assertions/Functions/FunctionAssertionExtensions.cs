using System;

namespace Ave.Extensions.Assertions.Functions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for Func{T} delegates.
    /// </summary>
    public static class FunctionAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="FunctionAssertions{T}"/> object for asserting on the specified function.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="func">The function to assert on.</param>
        /// <returns>A <see cref="FunctionAssertions{T}"/> instance.</returns>
        public static FunctionAssertions<T> Should<T>(this Func<T> func)
        {
            return new FunctionAssertions<T>(func);
        }

        /// <summary>
        /// Returns a <see cref="FunctionAssertions{T}"/> object for invoking an expression and asserting on its result.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TSubject">The type of the subject.</typeparam>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="subject">The subject to invoke the function on.</param>
        /// <param name="action">The function to invoke.</param>
        /// <returns>A <see cref="FunctionAssertions{T}"/> instance.</returns>
        public static FunctionAssertions<T> Invoking<TSubject, T>(this TSubject subject, Func<TSubject, T> action)
        {
            return new FunctionAssertions<T>(() => action(subject));
        }

        /// <summary>
        /// Returns a <see cref="MustFunctionAssertions{T}"/> object for asserting on the specified function.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="func">The function to assert on.</param>
        /// <returns>A <see cref="MustFunctionAssertions{T}"/> instance.</returns>
        public static MustFunctionAssertions<T> Must<T>(this Func<T> func)
        {
            return new MustFunctionAssertions<T>(func);
        }

        /// <summary>
        /// Returns a <see cref="MustFunctionAssertions{T}"/> object for invoking an expression and asserting on its result.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TSubject">The type of the subject.</typeparam>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="subject">The subject to invoke the function on.</param>
        /// <param name="action">The function to invoke.</param>
        /// <returns>A <see cref="MustFunctionAssertions{T}"/> instance.</returns>
        public static MustFunctionAssertions<T> MustInvoking<TSubject, T>(this TSubject subject, Func<TSubject, T> action)
        {
            return new MustFunctionAssertions<T>(() => action(subject));
        }
    }
}
