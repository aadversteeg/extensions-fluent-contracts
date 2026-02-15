using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for IComparable{T} types.
    /// </summary>
    public static class MustComparableContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustComparableContracts{T}"/> object for checking contracts on the specified comparable value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="T">The comparable type.</typeparam>
        /// <param name="subject">The value to check.</param>
        /// <returns>A <see cref="MustComparableContracts{T}"/> instance.</returns>
        public static MustComparableContracts<T> Must<T>(this T subject)
            where T : IComparable<T>
        {
            return new MustComparableContracts<T>(subject);
        }
    }
}
