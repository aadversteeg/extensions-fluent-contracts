using System.Xml.Linq;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for XML types.
    /// </summary>
    public static class XmlContractExtensions
    {
        /// <summary>
        /// Returns an <see cref="XDocumentContracts"/> object for checking contracts on the specified XDocument.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XDocument to check.</param>
        /// <returns>An <see cref="XDocumentContracts"/> instance.</returns>
        public static XDocumentContracts Should(this XDocument? subject)
        {
            return new XDocumentContracts(subject);
        }

        /// <summary>
        /// Returns an <see cref="XElementContracts"/> object for checking contracts on the specified XElement.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XElement to check.</param>
        /// <returns>An <see cref="XElementContracts"/> instance.</returns>
        public static XElementContracts Should(this XElement? subject)
        {
            return new XElementContracts(subject);
        }

        /// <summary>
        /// Returns an <see cref="XAttributeContracts"/> object for checking contracts on the specified XAttribute.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XAttribute to check.</param>
        /// <returns>An <see cref="XAttributeContracts"/> instance.</returns>
        public static XAttributeContracts Should(this XAttribute? subject)
        {
            return new XAttributeContracts(subject);
        }
    }
}
