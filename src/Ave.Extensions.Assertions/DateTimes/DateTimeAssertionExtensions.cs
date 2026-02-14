using System;

namespace Ave.Extensions.Assertions.DateTimes
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for DateTime and related types.
    /// </summary>
    public static class DateTimeAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="DateTimeAssertions"/> object for asserting on the specified DateTime.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The DateTime to assert on.</param>
        /// <returns>A <see cref="DateTimeAssertions"/> instance.</returns>
        public static DateTimeAssertions Should(this DateTime subject)
        {
            return new DateTimeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeAssertions"/> object for asserting on the specified nullable DateTime.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable DateTime to assert on.</param>
        /// <returns>A <see cref="DateTimeAssertions"/> instance.</returns>
        public static DateTimeAssertions Should(this DateTime? subject)
        {
            return new DateTimeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeAssertions"/> object for asserting on the specified DateTime.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The DateTime to assert on.</param>
        /// <returns>A <see cref="MustDateTimeAssertions"/> instance.</returns>
        public static MustDateTimeAssertions Must(this DateTime subject)
        {
            return new MustDateTimeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeAssertions"/> object for asserting on the specified nullable DateTime.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable DateTime to assert on.</param>
        /// <returns>A <see cref="MustDateTimeAssertions"/> instance.</returns>
        public static MustDateTimeAssertions Must(this DateTime? subject)
        {
            return new MustDateTimeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpanAssertions"/> object for asserting on the specified TimeSpan.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The TimeSpan to assert on.</param>
        /// <returns>A <see cref="TimeSpanAssertions"/> instance.</returns>
        public static TimeSpanAssertions Should(this TimeSpan subject)
        {
            return new TimeSpanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpanAssertions"/> object for asserting on the specified nullable TimeSpan.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable TimeSpan to assert on.</param>
        /// <returns>A <see cref="TimeSpanAssertions"/> instance.</returns>
        public static TimeSpanAssertions Should(this TimeSpan? subject)
        {
            return new TimeSpanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustTimeSpanAssertions"/> object for asserting on the specified TimeSpan.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The TimeSpan to assert on.</param>
        /// <returns>A <see cref="MustTimeSpanAssertions"/> instance.</returns>
        public static MustTimeSpanAssertions Must(this TimeSpan subject)
        {
            return new MustTimeSpanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustTimeSpanAssertions"/> object for asserting on the specified nullable TimeSpan.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable TimeSpan to assert on.</param>
        /// <returns>A <see cref="MustTimeSpanAssertions"/> instance.</returns>
        public static MustTimeSpanAssertions Must(this TimeSpan? subject)
        {
            return new MustTimeSpanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffsetAssertions"/> object for asserting on the specified DateTimeOffset.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The DateTimeOffset to assert on.</param>
        /// <returns>A <see cref="DateTimeOffsetAssertions"/> instance.</returns>
        public static DateTimeOffsetAssertions Should(this DateTimeOffset subject)
        {
            return new DateTimeOffsetAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffsetAssertions"/> object for asserting on the specified nullable DateTimeOffset.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable DateTimeOffset to assert on.</param>
        /// <returns>A <see cref="DateTimeOffsetAssertions"/> instance.</returns>
        public static DateTimeOffsetAssertions Should(this DateTimeOffset? subject)
        {
            return new DateTimeOffsetAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeOffsetAssertions"/> object for asserting on the specified DateTimeOffset.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The DateTimeOffset to assert on.</param>
        /// <returns>A <see cref="MustDateTimeOffsetAssertions"/> instance.</returns>
        public static MustDateTimeOffsetAssertions Must(this DateTimeOffset subject)
        {
            return new MustDateTimeOffsetAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeOffsetAssertions"/> object for asserting on the specified nullable DateTimeOffset.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable DateTimeOffset to assert on.</param>
        /// <returns>A <see cref="MustDateTimeOffsetAssertions"/> instance.</returns>
        public static MustDateTimeOffsetAssertions Must(this DateTimeOffset? subject)
        {
            return new MustDateTimeOffsetAssertions(subject);
        }
    }
}
