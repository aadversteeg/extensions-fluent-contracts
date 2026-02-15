using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for Func{T} delegates.
    /// </summary>
    public static class FunctionContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="FunctionContracts{T}"/> object for checking contracts on the specified function.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="func">The function to check.</param>
        /// <returns>A <see cref="FunctionContracts{T}"/> instance.</returns>
        public static FunctionContracts<T> Should<T>(this Func<T> func)
        {
            return new FunctionContracts<T>(func);
        }
    }
}
