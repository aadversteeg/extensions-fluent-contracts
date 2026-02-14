using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for IComparable{T} values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="T">The comparable type.</typeparam>
    public sealed class ComparableAssertions<T> : ComparableAssertionsBase<T, ComparableAssertions<T>>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The value to assert on.</param>
        public ComparableAssertions(T subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<T, Error>(ComparableAssertions<T> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ComparableAssertions<T> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
