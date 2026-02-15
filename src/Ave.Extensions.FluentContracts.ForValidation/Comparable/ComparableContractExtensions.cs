using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for IComparable{T} types.
    /// </summary>
    public static class ComparableContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="ComparableContracts{T}"/> object for checking contracts on the specified IComparable{T} value.
        /// Contract failures are recorded and returned as Result errors.
        /// Use this for custom types that implement IComparable{T} but don't have specialized contract methods.
        /// </summary>
        /// <typeparam name="T">The type implementing IComparable{T}.</typeparam>
        /// <param name="subject">The value to check.</param>
        /// <returns>A <see cref="ComparableContracts{T}"/> instance.</returns>
        public static ComparableContracts<T> ShouldBeComparable<T>(this T subject)
            where T : IComparable<T>
        {
            return new ComparableContracts<T>(subject);
        }
    }
}
