using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for date and time types.
    /// </summary>
    public static class MustDateTimeContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustDateTimeContracts"/> object for checking contracts on the specified DateTime value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The DateTime value to check.</param>
        /// <returns>A <see cref="MustDateTimeContracts"/> instance.</returns>
        public static MustDateTimeContracts Must(this DateTime subject)
        {
            return new MustDateTimeContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeContracts"/> object for checking contracts on the specified nullable DateTime value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable DateTime value to check.</param>
        /// <returns>A <see cref="MustDateTimeContracts"/> instance.</returns>
        public static MustDateTimeContracts Must(this DateTime? subject)
        {
            return new MustDateTimeContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeOffsetContracts"/> object for checking contracts on the specified DateTimeOffset value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The DateTimeOffset value to check.</param>
        /// <returns>A <see cref="MustDateTimeOffsetContracts"/> instance.</returns>
        public static MustDateTimeOffsetContracts Must(this DateTimeOffset subject)
        {
            return new MustDateTimeOffsetContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustDateTimeOffsetContracts"/> object for checking contracts on the specified nullable DateTimeOffset value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable DateTimeOffset value to check.</param>
        /// <returns>A <see cref="MustDateTimeOffsetContracts"/> instance.</returns>
        public static MustDateTimeOffsetContracts Must(this DateTimeOffset? subject)
        {
            return new MustDateTimeOffsetContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustTimeSpanContracts"/> object for checking contracts on the specified TimeSpan value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The TimeSpan value to check.</param>
        /// <returns>A <see cref="MustTimeSpanContracts"/> instance.</returns>
        public static MustTimeSpanContracts Must(this TimeSpan subject)
        {
            return new MustTimeSpanContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustTimeSpanContracts"/> object for checking contracts on the specified nullable TimeSpan value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable TimeSpan value to check.</param>
        /// <returns>A <see cref="MustTimeSpanContracts"/> instance.</returns>
        public static MustTimeSpanContracts Must(this TimeSpan? subject)
        {
            return new MustTimeSpanContracts(subject);
        }
    }
}
