using System.Xml.Linq;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for XML types.
    /// </summary>
    public static class MustXmlContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustXAttributeContracts"/> object for checking contracts on the specified XAttribute value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XAttribute value to check.</param>
        /// <returns>A <see cref="MustXAttributeContracts"/> instance.</returns>
        public static MustXAttributeContracts Must(this XAttribute? subject)
        {
            return new MustXAttributeContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustXDocumentContracts"/> object for checking contracts on the specified XDocument value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XDocument value to check.</param>
        /// <returns>A <see cref="MustXDocumentContracts"/> instance.</returns>
        public static MustXDocumentContracts Must(this XDocument? subject)
        {
            return new MustXDocumentContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustXElementContracts"/> object for checking contracts on the specified XElement value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XElement value to check.</param>
        /// <returns>A <see cref="MustXElementContracts"/> instance.</returns>
        public static MustXElementContracts Must(this XElement? subject)
        {
            return new MustXElementContracts(subject);
        }
    }
}
