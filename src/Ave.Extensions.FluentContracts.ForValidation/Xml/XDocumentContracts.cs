using System.Xml.Linq;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for XDocument values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class XDocumentContracts : XDocumentContractsBase<XDocumentContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XDocumentContracts"/> class.
        /// </summary>
        /// <param name="document">The XDocument to check.</param>
        public XDocumentContracts(XDocument? document) : base(document, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<XDocument?, Error>(XDocumentContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(XDocumentContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
