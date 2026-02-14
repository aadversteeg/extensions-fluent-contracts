using System;

namespace Ave.Extensions.Assertions.Numeric
{
    /// <summary>
    /// Contains assertion methods for nullable numeric values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class MustNullableNumericAssertions<T> : NullableNumericAssertionsBase<T, MustNullableNumericAssertions<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableNumericAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The nullable numeric value to assert on.</param>
        public MustNullableNumericAssertions(T? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
