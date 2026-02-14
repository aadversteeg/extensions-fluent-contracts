using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for IComparable{T} types.
    /// </summary>
    public static class ComparableAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="ComparableAssertions{T}"/> object for asserting on the specified IComparable{T} value.
        /// Assertion failures are recorded and returned as Result errors.
        /// Use this for custom types that implement IComparable{T} but don't have specialized assertion methods.
        /// </summary>
        /// <typeparam name="T">The type implementing IComparable{T}.</typeparam>
        /// <param name="subject">The value to assert on.</param>
        /// <returns>A <see cref="ComparableAssertions{T}"/> instance.</returns>
        public static ComparableAssertions<T> ShouldBeComparable<T>(this T subject)
            where T : IComparable<T>
        {
            return new ComparableAssertions<T>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustComparableAssertions{T}"/> object for asserting on the specified IComparable{T} value.
        /// Assertion failures throw framework-specific exceptions.
        /// Use this for custom types that implement IComparable{T} but don't have specialized assertion methods.
        /// </summary>
        /// <typeparam name="T">The type implementing IComparable{T}.</typeparam>
        /// <param name="subject">The value to assert on.</param>
        /// <returns>A <see cref="MustComparableAssertions{T}"/> instance.</returns>
        public static MustComparableAssertions<T> MustBeComparable<T>(this T subject)
            where T : IComparable<T>
        {
            return new MustComparableAssertions<T>(subject);
        }
    }
}
