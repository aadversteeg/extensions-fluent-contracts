using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for numeric values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class MustNumericContracts<T> : NumericContractsBase<T, MustNumericContracts<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNumericContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The numeric value to check.</param>
        public MustNumericContracts(T subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
