using System.Xml.Linq;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for XAttribute values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class XAttributeContracts : XAttributeContractsBase<XAttributeContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XAttributeContracts"/> class.
        /// </summary>
        /// <param name="attribute">The XAttribute to check.</param>
        public XAttributeContracts(XAttribute? attribute) : base(attribute, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<XAttribute?, Error>(XAttributeContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(XAttributeContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
