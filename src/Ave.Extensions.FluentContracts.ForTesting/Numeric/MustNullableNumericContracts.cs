using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for nullable numeric values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class MustNullableNumericContracts<T> : NullableNumericContractsBase<T, MustNullableNumericContracts<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableNumericContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The nullable numeric value to check.</param>
        public MustNullableNumericContracts(T? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
