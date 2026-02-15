using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for Guid types.
    /// </summary>
    public static class MustGuidContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustGuidContracts"/> object for checking contracts on the specified Guid value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The Guid value to check.</param>
        /// <returns>A <see cref="MustGuidContracts"/> instance.</returns>
        public static MustGuidContracts Must(this Guid subject)
        {
            return new MustGuidContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableGuidContracts"/> object for checking contracts on the specified nullable Guid value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable Guid value to check.</param>
        /// <returns>A <see cref="MustNullableGuidContracts"/> instance.</returns>
        public static MustNullableGuidContracts Must(this Guid? subject)
        {
            return new MustNullableGuidContracts(subject);
        }
    }
}
