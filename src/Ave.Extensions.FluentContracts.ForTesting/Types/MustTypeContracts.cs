using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for Type values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustTypeContracts : TypeContractsBase<MustTypeContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustTypeContracts"/> class.
        /// </summary>
        /// <param name="subject">The Type value to check.</param>
        public MustTypeContracts(Type? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
