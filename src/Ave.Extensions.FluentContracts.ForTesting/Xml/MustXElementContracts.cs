using System.Xml.Linq;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for XElement values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXElementContracts : XElementContractsBase<MustXElementContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXElementContracts"/> class.
        /// </summary>
        /// <param name="subject">The XElement value to check.</param>
        public MustXElementContracts(XElement? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
