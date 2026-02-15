using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for Guid types.
    /// </summary>
    public static class GuidContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="GuidContracts"/> object for checking contracts on the specified Guid.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Guid to check.</param>
        /// <returns>A <see cref="GuidContracts"/> instance.</returns>
        public static GuidContracts Should(this Guid subject)
        {
            return new GuidContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="NullableGuidContracts"/> object for checking contracts on the specified nullable Guid.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable Guid to check.</param>
        /// <returns>A <see cref="NullableGuidContracts"/> instance.</returns>
        public static NullableGuidContracts Should(this Guid? subject)
        {
            return new NullableGuidContracts(subject);
        }
    }
}
