using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for DateTime values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustDateTimeAssertions : DateTimeAssertionsBase<MustDateTimeAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDateTimeAssertions"/> class.
        /// </summary>
        /// <param name="subject">The DateTime value to assert on.</param>
        public MustDateTimeAssertions(DateTime? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
