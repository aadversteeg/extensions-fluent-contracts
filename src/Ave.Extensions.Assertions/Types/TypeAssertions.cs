using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for Type values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class TypeAssertions : TypeAssertionsBase<TypeAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAssertions"/> class.
        /// </summary>
        /// <param name="subject">The Type to assert on.</param>
        public TypeAssertions(Type? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Type?, Error>(TypeAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(TypeAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
