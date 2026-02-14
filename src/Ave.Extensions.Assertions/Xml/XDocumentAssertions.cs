using System.Xml.Linq;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Contains assertion methods for XDocument values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class XDocumentAssertions : XDocumentAssertionsBase<XDocumentAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XDocumentAssertions"/> class.
        /// </summary>
        /// <param name="document">The XDocument to assert on.</param>
        public XDocumentAssertions(XDocument? document) : base(document, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<XDocument?, Error>(XDocumentAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(XDocumentAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
