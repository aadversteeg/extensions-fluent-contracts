using System.Xml.Linq;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Contains assertion methods for XAttribute values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustXAttributeAssertions : XAttributeAssertionsBase<MustXAttributeAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustXAttributeAssertions"/> class.
        /// </summary>
        /// <param name="attribute">The XAttribute to assert on.</param>
        public MustXAttributeAssertions(XAttribute? attribute) : base(attribute, throwOnFailure: true)
        {
        }
    }
}
