using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for nullable Guid values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustNullableGuidContracts : NullableGuidContractsBase<MustNullableGuidContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableGuidContracts"/> class.
        /// </summary>
        /// <param name="subject">The nullable Guid value to check.</param>
        public MustNullableGuidContracts(Guid? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
