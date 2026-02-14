using System.Xml.Linq;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for XElement values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class XElementAssertions : XElementAssertionsBase<XElementAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XElementAssertions"/> class.
        /// </summary>
        /// <param name="element">The XElement to assert on.</param>
        public XElementAssertions(XElement? element) : base(element, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<XElement?, Error>(XElementAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(XElementAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
