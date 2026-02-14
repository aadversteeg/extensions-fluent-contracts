namespace Ave.Extensions.Assertions.Strings
{
    /// <summary>
    /// Extension methods for string assertions.
    /// </summary>
    public static class StringAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="StringAssertions"/> object for asserting on the specified string.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The string to assert on.</param>
        /// <returns>A <see cref="StringAssertions"/> instance.</returns>
        public static StringAssertions Should(this string? subject)
        {
            return new StringAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustStringAssertions"/> object for asserting on the specified string.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The string to assert on.</param>
        /// <returns>A <see cref="MustStringAssertions"/> instance.</returns>
        public static MustStringAssertions Must(this string? subject)
        {
            return new MustStringAssertions(subject);
        }
    }
}
