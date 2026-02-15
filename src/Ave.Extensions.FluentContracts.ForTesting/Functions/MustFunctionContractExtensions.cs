using System;
using System.Threading.Tasks;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for async function delegates.
    /// </summary>
    public static class MustFunctionContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustFunctionContracts"/> object for checking contracts on the specified async function.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="function">The async function to check.</param>
        /// <returns>A <see cref="MustFunctionContracts"/> instance.</returns>
        public static MustFunctionContracts Must(this Func<Task> function)
        {
            return new MustFunctionContracts(function);
        }
    }
}
