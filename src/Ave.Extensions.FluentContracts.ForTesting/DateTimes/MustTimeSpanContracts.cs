using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for TimeSpan values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustTimeSpanContracts : TimeSpanContractsBase<MustTimeSpanContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustTimeSpanContracts"/> class.
        /// </summary>
        /// <param name="subject">The TimeSpan value to check.</param>
        public MustTimeSpanContracts(TimeSpan? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
