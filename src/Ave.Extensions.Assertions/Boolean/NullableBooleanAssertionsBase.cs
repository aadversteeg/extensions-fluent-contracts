namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class for nullable boolean assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class NullableBooleanAssertionsBase<TSelf> : Assertions<bool?, TSelf>
        where TSelf : NullableBooleanAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBooleanAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The nullable boolean value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected NullableBooleanAssertionsBase(bool? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the nullable boolean has a value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue,
                BooleanAssertionCodes.HaveValue,
                "Expected a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable boolean does not have a value (is null).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveValue(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => !s.HasValue,
                BooleanAssertionCodes.NotHaveValue,
                $"Did not expect a value but found {Subject}",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the nullable boolean is null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNull(string because = "", params object[] becauseArgs)
        {
            return NotHaveValue(because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the nullable boolean is not null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeNull(string because = "", params object[] becauseArgs)
        {
            return HaveValue(because, becauseArgs);
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
                Subject.HasValue
                    ? $"Expected true but found {Subject.Value}"
                    : "Expected true but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
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
                Subject.HasValue
                    ? $"Expected false but found {Subject.Value}"
                    : "Expected false but found null",
                e => e.With("actual", Subject?.ToString() ?? "(null)")
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
                Subject.HasValue
                    ? $"Expected {expected} but found {Subject.Value}"
                    : $"Expected {expected} but found null",
                e => e.With("expected", expected)
                      .With("actual", Subject?.ToString() ?? "(null)")
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
                      .With("actual", Subject?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the value implies the specified consequent value.
        /// </summary>
        /// <param name="consequent">The consequent value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Imply(bool consequent, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s.HasValue && (!s.Value || consequent),
                BooleanAssertionCodes.Imply,
                Subject.HasValue
                    ? $"Expected {Subject.Value} to imply {consequent} but it did not"
                    : "Expected a value to check implication but found null",
                e => e.With("antecedent", Subject?.ToString() ?? "(null)")
                      .With("consequent", consequent)
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
