using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Guids
{
    /// <summary>
    /// Contains assertion methods for nullable Guid values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class NullableGuidAssertions : NullableGuidAssertionsBase<NullableGuidAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableGuidAssertions"/> class.
        /// </summary>
        /// <param name="subject">The nullable Guid value to assert on.</param>
        public NullableGuidAssertions(Guid? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Guid?, Error>(NullableGuidAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(NullableGuidAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
