using System;
using System.Xml.Linq;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for XDocument assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class XDocumentAssertionsBase<TSelf> : Assertions<XDocument?, TSelf>
        where TSelf : XDocumentAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XDocumentAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The XDocument to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected XDocumentAssertionsBase(XDocument? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current XDocument equals the expected document using Object.Equals.
        /// </summary>
        /// <param name="expected">The expected document.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(XDocument? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => Equals(s, expected),
                XmlAssertionCodes.Be,
                $"Expected XDocument to be '{FormatDocument(expected)}' but found '{FormatDocument(Subject)}'",
                e => e.With("expected", FormatDocument(expected))
                      .With("actual", FormatDocument(Subject))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XDocument does not equal the unexpected document.
        /// </summary>
        /// <param name="unexpected">The unexpected document.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(XDocument? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !Equals(s, unexpected),
                XmlAssertionCodes.NotBe,
                $"Did not expect XDocument to be '{FormatDocument(unexpected)}'",
                e => e.With("unexpected", FormatDocument(unexpected))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XDocument is equivalent to the expected document using XNode.DeepEquals.
        /// </summary>
        /// <param name="expected">The expected document.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeEquivalentTo(XDocument? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && expected is not null && XNode.DeepEquals(s, expected),
                XmlAssertionCodes.BeEquivalentTo,
                Subject is null
                    ? "Expected XDocument to be equivalent but subject is null"
                    : expected is null
                        ? "Expected XDocument to be equivalent but expected is null"
                        : $"Expected XDocument to be equivalent to '{FormatDocument(expected)}' but found '{FormatDocument(Subject)}'",
                e => e.With("expected", FormatDocument(expected))
                      .With("actual", FormatDocument(Subject))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XDocument is not equivalent to the unexpected document using XNode.DeepEquals.
        /// </summary>
        /// <param name="unexpected">The unexpected document.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeEquivalentTo(XDocument? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is null || unexpected is null || !XNode.DeepEquals(s, unexpected),
                XmlAssertionCodes.NotBeEquivalentTo,
                $"Did not expect XDocument to be equivalent to '{FormatDocument(unexpected)}'",
                e => e.With("unexpected", FormatDocument(unexpected))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XDocument has a root element with the specified name.
        /// </summary>
        /// <param name="expected">The expected name of the root element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf HaveRoot(string expected, string because = "", params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return HaveRoot(XName.Get(expected), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current XDocument has a root element with the specified name.
        /// </summary>
        /// <param name="expected">The expected XName of the root element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf HaveRoot(XName expected, string because = "", params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return Assert(
                s => s?.Root is not null && s.Root.Name == expected,
                XmlAssertionCodes.HaveRoot,
                Subject is null
                    ? $"Expected XDocument to have root element '{expected}' but document is null"
                    : Subject.Root is null
                        ? $"Expected XDocument to have root element '{expected}' but document has no root element"
                        : $"Expected XDocument to have root element '{expected}' but found '{Subject.Root.Name}'",
                e => e.With("expectedRoot", expected.ToString())
                      .With("actualRoot", Subject?.Root?.Name.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the root element of the current XDocument has a direct child element with the specified name.
        /// </summary>
        /// <param name="expected">The expected name of the child element.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expected is null.</exception>
        public TSelf HaveElement(string expected, string because = "", params object[] becauseArgs)
        {
            if (expected is null)
            {
                throw new ArgumentNullException(nameof(expected));
            }

            return HaveElement(XName.Get(expected), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the root element of the current XDocument has a direct child element with the specified name.
        /// </summary>
        /// <param name="expected">The expected XName of the child element.</param>
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
                s => s?.Root?.Element(expected) is not null,
                XmlAssertionCodes.HaveElement,
                Subject is null
                    ? $"Expected XDocument to have element '{expected}' but document is null"
                    : Subject.Root is null
                        ? $"Expected XDocument to have element '{expected}' but document has no root element"
                        : $"Expected XDocument to have element '{expected}' but no such element was found",
                e => e.With("expectedElement", expected.ToString())
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        private static string FormatDocument(XDocument? document)
        {
            if (document is null)
            {
                return "(null)";
            }

            var str = document.ToString();
            return str.Length > 100 ? str.Substring(0, 100) + "..." : str;
        }
    }
}
