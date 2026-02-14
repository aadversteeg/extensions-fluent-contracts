using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for nullable Guid values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustNullableGuidAssertions : NullableGuidAssertionsBase<MustNullableGuidAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableGuidAssertions"/> class.
        /// </summary>
        /// <param name="subject">The nullable Guid value to assert on.</param>
        public MustNullableGuidAssertions(Guid? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
