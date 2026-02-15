using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for Guid values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustGuidContracts : GuidContractsBase<MustGuidContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustGuidContracts"/> class.
        /// </summary>
        /// <param name="subject">The Guid value to check.</param>
        public MustGuidContracts(Guid subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
