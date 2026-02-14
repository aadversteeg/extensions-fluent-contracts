namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for boolean values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustBooleanAssertions : BooleanAssertionsBase<MustBooleanAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustBooleanAssertions"/> class.
        /// </summary>
        /// <param name="subject">The boolean value to assert on.</param>
        public MustBooleanAssertions(bool subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
