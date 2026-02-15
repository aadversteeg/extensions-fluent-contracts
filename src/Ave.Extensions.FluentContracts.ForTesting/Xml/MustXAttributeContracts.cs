using System.Xml.Linq;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for XAttribute values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXAttributeContracts : XAttributeContractsBase<MustXAttributeContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXAttributeContracts"/> class.
        /// </summary>
        /// <param name="subject">The XAttribute value to check.</param>
        public MustXAttributeContracts(XAttribute? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
