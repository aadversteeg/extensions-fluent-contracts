using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for nullable numeric values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    public sealed class NullableNumericAssertions<T> : NullableNumericAssertionsBase<T, NullableNumericAssertions<T>>
        where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableNumericAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The nullable numeric value to assert on.</param>
        public NullableNumericAssertions(T? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<T?, Error>(NullableNumericAssertions<T> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(NullableNumericAssertions<T> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
