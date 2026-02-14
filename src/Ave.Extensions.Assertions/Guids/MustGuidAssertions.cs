using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for Guid values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustGuidAssertions : GuidAssertionsBase<MustGuidAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustGuidAssertions"/> class.
        /// </summary>
        /// <param name="subject">The Guid value to assert on.</param>
        public MustGuidAssertions(Guid subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
