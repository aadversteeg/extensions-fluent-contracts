using System;

namespace Ave.Extensions.Assertions.Numeric
{
    /// <summary>
    /// Contains assertion methods for numeric values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class MustNumericAssertions<T> : NumericAssertionsBase<T, MustNumericAssertions<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNumericAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The numeric value to assert on.</param>
        public MustNumericAssertions(T subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
