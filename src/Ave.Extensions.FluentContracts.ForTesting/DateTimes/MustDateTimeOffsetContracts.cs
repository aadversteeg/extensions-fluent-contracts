using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for DateTimeOffset values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustDateTimeOffsetContracts : DateTimeOffsetContractsBase<MustDateTimeOffsetContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDateTimeOffsetContracts"/> class.
        /// </summary>
        /// <param name="subject">The DateTimeOffset value to check.</param>
        public MustDateTimeOffsetContracts(DateTimeOffset? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
