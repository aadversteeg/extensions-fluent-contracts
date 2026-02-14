using System.Xml.Linq;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for XElement values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXElementAssertions : XElementAssertionsBase<MustXElementAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXElementAssertions"/> class.
        /// </summary>
        /// <param name="element">The XElement to assert on.</param>
        public MustXElementAssertions(XElement? element) : base(element, throwOnFailure: true)
        {
        }
    }
}
