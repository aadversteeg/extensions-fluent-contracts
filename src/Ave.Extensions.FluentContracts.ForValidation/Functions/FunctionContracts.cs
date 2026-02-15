using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for Func{T} delegates.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    public sealed class FunctionContracts<T> : FunctionContractsBase<T, FunctionContracts<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionContracts{T}"/> class.
        /// </summary>
        /// <param name="func">The function to check.</param>
        public FunctionContracts(Func<T> func) : base(func, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Func<T>, Error>(FunctionContracts<T> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(FunctionContracts<T> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
