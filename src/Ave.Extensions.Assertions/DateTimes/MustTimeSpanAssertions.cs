using System;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for TimeSpan values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustTimeSpanAssertions : TimeSpanAssertionsBase<MustTimeSpanAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustTimeSpanAssertions"/> class.
        /// </summary>
        /// <param name="subject">The TimeSpan value to assert on.</param>
        public MustTimeSpanAssertions(TimeSpan? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
