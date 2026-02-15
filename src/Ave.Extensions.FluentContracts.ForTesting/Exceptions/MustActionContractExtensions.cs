using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for Action delegates.
    /// </summary>
    public static class MustActionContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustActionContracts"/> object for checking contracts on the specified action.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="action">The action to check.</param>
        /// <returns>A <see cref="MustActionContracts"/> instance.</returns>
        public static MustActionContracts Must(this Action action)
        {
            return new MustActionContracts(action);
        }
    }
}
