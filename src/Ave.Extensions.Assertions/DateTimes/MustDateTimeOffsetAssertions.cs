using System;

namespace Ave.Extensions.Assertions.DateTimes
{
    /// <summary>
    /// Contains assertion methods for DateTimeOffset values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustDateTimeOffsetAssertions : DateTimeOffsetAssertionsBase<MustDateTimeOffsetAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDateTimeOffsetAssertions"/> class.
        /// </summary>
        /// <param name="subject">The DateTimeOffset value to assert on.</param>
        public MustDateTimeOffsetAssertions(DateTimeOffset? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
