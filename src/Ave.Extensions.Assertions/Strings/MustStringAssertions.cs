namespace Ave.Extensions.Assertions.Strings
{
    /// <summary>
    /// Contains assertion methods for string values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustStringAssertions : StringAssertionsBase<MustStringAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustStringAssertions"/> class.
        /// </summary>
        /// <param name="subject">The string value to assert on.</param>
        public MustStringAssertions(string? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
