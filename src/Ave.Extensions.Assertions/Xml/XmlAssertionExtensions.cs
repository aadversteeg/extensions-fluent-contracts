using System.Xml.Linq;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for XML types.
    /// </summary>
    public static class XmlAssertionExtensions
    {
        /// <summary>
        /// Returns an <see cref="XDocumentAssertions"/> object for asserting on the specified XDocument.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XDocument to assert on.</param>
        /// <returns>An <see cref="XDocumentAssertions"/> instance.</returns>
        public static XDocumentAssertions Should(this XDocument? subject)
        {
            return new XDocumentAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustXDocumentAssertions"/> object for asserting on the specified XDocument.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XDocument to assert on.</param>
        /// <returns>A <see cref="MustXDocumentAssertions"/> instance.</returns>
        public static MustXDocumentAssertions Must(this XDocument? subject)
        {
            return new MustXDocumentAssertions(subject);
        }

        /// <summary>
        /// Returns an <see cref="XElementAssertions"/> object for asserting on the specified XElement.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XElement to assert on.</param>
        /// <returns>An <see cref="XElementAssertions"/> instance.</returns>
        public static XElementAssertions Should(this XElement? subject)
        {
            return new XElementAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustXElementAssertions"/> object for asserting on the specified XElement.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XElement to assert on.</param>
        /// <returns>A <see cref="MustXElementAssertions"/> instance.</returns>
        public static MustXElementAssertions Must(this XElement? subject)
        {
            return new MustXElementAssertions(subject);
        }

        /// <summary>
        /// Returns an <see cref="XAttributeAssertions"/> object for asserting on the specified XAttribute.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The XAttribute to assert on.</param>
        /// <returns>An <see cref="XAttributeAssertions"/> instance.</returns>
        public static XAttributeAssertions Should(this XAttribute? subject)
        {
            return new XAttributeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustXAttributeAssertions"/> object for asserting on the specified XAttribute.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The XAttribute to assert on.</param>
        /// <returns>A <see cref="MustXAttributeAssertions"/> instance.</returns>
        public static MustXAttributeAssertions Must(this XAttribute? subject)
        {
            return new MustXAttributeAssertions(subject);
        }
    }
}
