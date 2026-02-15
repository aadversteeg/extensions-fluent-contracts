using System.Xml.Linq;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for XElement values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class XElementContracts : XElementContractsBase<XElementContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XElementContracts"/> class.
        /// </summary>
        /// <param name="element">The XElement to check.</param>
        public XElementContracts(XElement? element) : base(element, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<XElement?, Error>(XElementContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(XElementContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
