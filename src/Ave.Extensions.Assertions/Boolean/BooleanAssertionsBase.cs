namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for boolean assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class BooleanAssertionsBase<TSelf> : Assertions<bool, TSelf>
        where TSelf : BooleanAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The boolean value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected BooleanAssertionsBase(bool subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the value is true.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeTrue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == true,
                BooleanAssertionCodes.BeTrue,
                $"Expected true but found {Subject}",
                e => e.With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is false.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeFalse(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == false,
                BooleanAssertionCodes.BeFalse,
                $"Expected false but found {Subject}",
                e => e.With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is equal to the expected value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(bool expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                BooleanAssertionCodes.Be,
                $"Expected {expected} but found {Subject}",
                e => e.With("expected", expected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value is not equal to the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(bool unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                BooleanAssertionCodes.NotBe,
                $"Did not expect {unexpected}",
                e => e.With("unexpected", unexpected)
                      .With("actual", Subject)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value implies the specified consequent value.
        /// In logical terms: antecedent implies consequent is equivalent to !antecedent || consequent.
        /// </summary>
        /// <param name="consequent">The consequent value (right side of implication).</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Imply(bool consequent, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s || consequent,
                BooleanAssertionCodes.Imply,
                $"Expected {Subject} to imply {consequent} but it did not",
                e => e.With("antecedent", Subject)
                      .With("consequent", consequent)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
