using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for Guid values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class GuidAssertions : GuidAssertionsBase<GuidAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidAssertions"/> class.
        /// </summary>
        /// <param name="subject">The Guid value to assert on.</param>
        public GuidAssertions(Guid subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Guid, Error>(GuidAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(GuidAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
