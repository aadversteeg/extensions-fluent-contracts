using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for IComparable{T} values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The comparable type.</typeparam>
    public sealed class MustComparableContracts<T> : ComparableContractsBase<T, MustComparableContracts<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustComparableContracts{T}"/> class.
        /// </summary>
        /// <param name="subject">The value to check.</param>
        public MustComparableContracts(T subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
