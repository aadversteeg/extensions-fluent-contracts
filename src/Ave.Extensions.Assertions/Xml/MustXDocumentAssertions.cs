using System.Xml.Linq;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Contains assertion methods for XDocument values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXDocumentAssertions : XDocumentAssertionsBase<MustXDocumentAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXDocumentAssertions"/> class.
        /// </summary>
        /// <param name="document">The XDocument to assert on.</param>
        public MustXDocumentAssertions(XDocument? document) : base(document, throwOnFailure: true)
        {
        }
    }
}
