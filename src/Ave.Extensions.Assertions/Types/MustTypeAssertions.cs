using System;

namespace Ave.Extensions.Assertions.Types
{
    /// <summary>
    /// Contains assertion methods for Type values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustTypeAssertions : TypeAssertionsBase<MustTypeAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustTypeAssertions"/> class.
        /// </summary>
        /// <param name="subject">The Type to assert on.</param>
        public MustTypeAssertions(Type? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
