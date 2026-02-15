using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for DateTime values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustDateTimeContracts : DateTimeContractsBase<MustDateTimeContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustDateTimeContracts"/> class.
        /// </summary>
        /// <param name="subject">The DateTime value to check.</param>
        public MustDateTimeContracts(DateTime? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
