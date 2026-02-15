using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for Type values.
    /// </summary>
    public static class MustTypeContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustTypeContracts"/> object for checking contracts on the specified Type value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The Type value to check.</param>
        /// <returns>A <see cref="MustTypeContracts"/> instance.</returns>
        public static MustTypeContracts Must(this Type? subject)
        {
            return new MustTypeContracts(subject);
        }
    }
}
