using System.Collections.Generic;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for string collections.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustStringCollectionContracts : StringCollectionContractsBase<MustStringCollectionContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustStringCollectionContracts"/> class.
        /// </summary>
        /// <param name="subject">The string collection to check.</param>
        public MustStringCollectionContracts(IEnumerable<string?>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
