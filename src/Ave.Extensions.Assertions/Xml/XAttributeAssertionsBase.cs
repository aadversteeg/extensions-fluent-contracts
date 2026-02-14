using System.Xml.Linq;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Base class for XAttribute assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class XAttributeAssertionsBase<TSelf> : Assertions<XAttribute?, TSelf>
        where TSelf : XAttributeAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XAttributeAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The XAttribute to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected XAttributeAssertionsBase(XAttribute? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current XAttribute equals the expected attribute (same name and value).
        /// </summary>
        /// <param name="expected">The expected attribute.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(XAttribute? expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s?.Name == expected?.Name && s?.Value == expected?.Value,
                XmlAssertionCodes.Be,
                $"Expected XAttribute to be '{FormatAttribute(expected)}' but found '{FormatAttribute(Subject)}'",
                e => e.With("expected", FormatAttribute(expected))
                      .With("actual", FormatAttribute(Subject))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XAttribute does not equal the unexpected attribute.
        /// </summary>
        /// <param name="unexpected">The unexpected attribute.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(XAttribute? unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !(s?.Name == unexpected?.Name && s?.Value == unexpected?.Value),
                XmlAssertionCodes.NotBe,
                $"Did not expect XAttribute to be '{FormatAttribute(unexpected)}'",
                e => e.With("unexpected", FormatAttribute(unexpected))
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current XAttribute has the specified value.
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
                    ? $"Expected XAttribute to have value '{expected}' but attribute is null"
                    : $"Expected XAttribute '{Subject.Name}' to have value '{expected}' but found '{Subject.Value}'",
                e => e.With("expectedValue", expected ?? "(null)")
                      .With("actualValue", Subject?.Value ?? "(null)")
                      .With("attributeName", Subject?.Name.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        private static string FormatAttribute(XAttribute? attribute)
        {
            if (attribute is null)
            {
                return "(null)";
            }

            return $"{attribute.Name}=\"{attribute.Value}\"";
        }
    }
}
