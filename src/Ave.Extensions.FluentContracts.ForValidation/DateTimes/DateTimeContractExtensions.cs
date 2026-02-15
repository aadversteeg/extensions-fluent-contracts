using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for DateTime and related types.
    /// </summary>
    public static class DateTimeContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="DateTimeContracts"/> object for checking contracts on the specified DateTime.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The DateTime to check.</param>
        /// <returns>A <see cref="DateTimeContracts"/> instance.</returns>
        public static DateTimeContracts Should(this DateTime subject)
        {
            return new DateTimeContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeContracts"/> object for checking contracts on the specified nullable DateTime.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable DateTime to check.</param>
        /// <returns>A <see cref="DateTimeContracts"/> instance.</returns>
        public static DateTimeContracts Should(this DateTime? subject)
        {
            return new DateTimeContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpanContracts"/> object for checking contracts on the specified TimeSpan.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The TimeSpan to check.</param>
        /// <returns>A <see cref="TimeSpanContracts"/> instance.</returns>
        public static TimeSpanContracts Should(this TimeSpan subject)
        {
            return new TimeSpanContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="TimeSpanContracts"/> object for checking contracts on the specified nullable TimeSpan.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable TimeSpan to check.</param>
        /// <returns>A <see cref="TimeSpanContracts"/> instance.</returns>
        public static TimeSpanContracts Should(this TimeSpan? subject)
        {
            return new TimeSpanContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffsetContracts"/> object for checking contracts on the specified DateTimeOffset.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The DateTimeOffset to check.</param>
        /// <returns>A <see cref="DateTimeOffsetContracts"/> instance.</returns>
        public static DateTimeOffsetContracts Should(this DateTimeOffset subject)
        {
            return new DateTimeOffsetContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="DateTimeOffsetContracts"/> object for checking contracts on the specified nullable DateTimeOffset.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable DateTimeOffset to check.</param>
        /// <returns>A <see cref="DateTimeOffsetContracts"/> instance.</returns>
        public static DateTimeOffsetContracts Should(this DateTimeOffset? subject)
        {
            return new DateTimeOffsetContracts(subject);
        }
    }
}
