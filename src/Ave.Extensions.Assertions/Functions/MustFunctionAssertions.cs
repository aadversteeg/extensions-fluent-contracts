using System;

namespace Ave.Extensions.Assertions.Functions
{
    /// <summary>
    /// Contains assertion methods for Func{T} delegates.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    public sealed class MustFunctionAssertions<T> : FunctionAssertionsBase<T, MustFunctionAssertions<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustFunctionAssertions{T}"/> class.
        /// </summary>
        /// <param name="func">The function to assert on.</param>
        public MustFunctionAssertions(Func<T> func) : base(func, throwOnFailure: true)
        {
        }
    }
}
