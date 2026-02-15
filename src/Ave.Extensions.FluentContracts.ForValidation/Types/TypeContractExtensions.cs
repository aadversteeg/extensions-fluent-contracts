using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods for Type contracts.
    /// </summary>
    public static class TypeContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="TypeContracts"/> object for checking contracts on the specified Type.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Type to check.</param>
        /// <returns>A <see cref="TypeContracts"/> instance.</returns>
        public static TypeContracts Should(this Type? subject)
        {
            return new TypeContracts(subject);
        }
    }
}
