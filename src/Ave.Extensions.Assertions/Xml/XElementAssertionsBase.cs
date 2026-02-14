using System;
using System.Xml.Linq;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Base class for XElement assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class XElementAssertionsBase<TSelf> : Assertions<XElement?, TSelf>
        where TSelf : XElementAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XElementAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The XElement to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected XElementAssertionsBase(XElement? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current XElement equals the expected element using XNode.DeepEquals.
        /// </summary>
        /// <param name="expected">The expected element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(XElement? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => XNode.DeepEquals(s, expected),
                XmlAssertionCodes.Be,
                $"Expected XElement to be '{FormatElement(expected)}' but found '{FormatElement(Subject)}'",
                e => e.With("expected", FormatElement(expected))
                      .With("actual", FormatElement(Subject))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement does not equal the unexpected element using XNode.DeepEquals.
        /// </summary>
        /// <param name="unexpected">The unexpected element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(XElement? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => (s is null && unexpected is not null) || !XNode.DeepEquals(s, unexpected),
                XmlAssertionCodes.NotBe,
                $"Did not expect XElement to be '{FormatElement(unexpected)}'",
                e => e.With("unexpected", FormatElement(unexpected))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement is equivalent to the expected element.
        /// </summary>
        /// <param name="expected">The expected element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeEquivalentTo(XElement? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && expected is not null && XNode.DeepEquals(s, expected),
                XmlAssertionCodes.BeEquivalentTo,
                Subject is null
                    ? "Expected XElement to be equivalent but subject is null"
                    : expected is null
                        ? "Expected XElement to be equivalent but expected is null"
                        : $"Expected XElement to be equivalent to '{FormatElement(expected)}' but found '{FormatElement(Subject)}'",
                e => e.With("expected", FormatElement(expected))
                      .With("actual", FormatElement(Subject))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement is not equivalent to the unexpected element.
        /// </summary>
        /// <param name="unexpected">The unexpected element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeEquivalentTo(XElement? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || unexpected is null || !XNode.DeepEquals(s, unexpected),
                XmlAssertionCodes.NotBeEquivalentTo,
                $"Did not expect XElement to be equivalent to '{FormatElement(unexpected)}'",
                e => e.With("unexpected", FormatElement(unexpected))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement has the specified value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.Value == expected,
                XmlAssertionCodes.HaveValue,
                Subject is null
                    ? $"Expected XElement to have value '{expected}' but element is null"
                    : $"Expected XElement '{Subject.Name}' to have value '{expected}' but found '{Subject.Value}'",
                e => e.With("expectedValue", expected ?? "(null)")
                      .With("actualValue", Subject?.Value ?? "(null)")
                      .With("elementName", Subject?.Name.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement has an attribute with the specified name and value.
        /// </summary>
        /// <param name="expectedName">The expected attribute name.</param>
        /// <param name="expectedValue">The expected attribute value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expectedName is null or empty.</exception>
        public TSelf HaveAttribute(string expectedName, string expectedValue, string because = "", params object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(expectedName))
            {
                throw new ArgumentNullException(nameof(expectedName));
            }

            return HaveAttribute(XName.Get(expectedName), expectedValue, because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current XElement has an attribute with the specified name and value.
        /// </summary>
        /// <param name="expectedName">The expected attribute XName.</param>
        /// <param name="expectedValue">The expected attribute value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expectedName is null.</exception>
        public TSelf HaveAttribute(XName expectedName, string expectedValue, string because = "", params object[] becauseArgs)
        {
            if (expectedName is null)
            {
                throw new ArgumentNullException(nameof(expectedName));
            }

            return Assert(
                s =>
                {
                    if (s is null)
                    {
                        return false;
                    }
                    var attr = s.Attribute(expectedName);
                    return attr is not null && attr.Value == expectedValue;
                },
                XmlAssertionCodes.HaveAttribute,
                Subject is null
                    ? $"Expected XElement to have attribute '{expectedName}' with value '{expectedValue}' but element is null"
                    : Subject.Attribute(expectedName) is null
                        ? $"Expected XElement '{Subject.Name}' to have attribute '{expectedName}' with value '{expectedValue}' but no such attribute was found"
                        : $"Expected XElement '{Subject.Name}' to have attribute '{expectedName}' with value '{expectedValue}' but found '{Subject.Attribute(expectedName)?.Value}'",
                e => e.With("expectedAttribute", expectedName.ToString())
                      .With("expectedValue", expectedValue ?? "(null)")
                      .With("actualValue", Subject?.Attribute(expectedName)?.Value ?? "(not found)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XElement has a direct child element with the specified name.
        /// </summary>
        /// <param name="expected">The expected child element name.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null or empty.</exception>
        public TSelf HaveElement(string expected, string because = "", params object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(expected))
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return HaveElement(XName.Get(expected), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current XElement has a direct child element with the specified name.
        /// </summary>
        /// <param name="expected">The expected child element XName.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf HaveElement(XName expected, string because = "", params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return Assert(
                s => s?.Element(expected) is not null,
                XmlAssertionCodes.HaveElement,
                Subject is null
                    ? $"Expected XElement to have child element '{expected}' but element is null"
                    : $"Expected XElement '{Subject.Name}' to have child element '{expected}' but no such element was found",
                e => e.With("expectedElement", expected.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        private static string FormatElement(XElement? element)
        {
            if (element is null)
            {
                return "(null)";
            }

            var str = element.ToString();
            return str.Length > 100 ? str.Substring(0, 100) + "..." : str;
        }
    }
}
