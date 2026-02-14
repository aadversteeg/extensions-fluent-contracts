using System;

namespace Ave.Extensions.Assertions.Comparable
{
    /// <summary>
    /// Contains assertion methods for IComparable{T} values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The comparable type.</typeparam>
    public sealed class MustComparableAssertions<T> : ComparableAssertionsBase<T, MustComparableAssertions<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustComparableAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The value to assert on.</param>
        public MustComparableAssertions(T subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
