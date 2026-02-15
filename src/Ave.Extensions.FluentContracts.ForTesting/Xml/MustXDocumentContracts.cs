using System.Xml.Linq;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for XDocument values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXDocumentContracts : XDocumentContractsBase<MustXDocumentContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXDocumentContracts"/> class.
        /// </summary>
        /// <param name="subject">The XDocument value to check.</param>
        public MustXDocumentContracts(XDocument? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
