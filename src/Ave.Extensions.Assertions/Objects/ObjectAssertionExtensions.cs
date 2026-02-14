namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods for object assertions.
    /// </summary>
    public static class ObjectAssertionExtensions
    {
        /// <summary>
        /// Returns an <see cref="ObjectAssertions"/> object for asserting on the specified object.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The object to assert on.</param>
        /// <returns>An <see cref="ObjectAssertions"/> instance.</returns>
        public static ObjectAssertions Should(this object? subject)
        {
            return new ObjectAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustObjectAssertions"/> object for asserting on the specified object.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The object to assert on.</param>
        /// <returns>A <see cref="MustObjectAssertions"/> instance.</returns>
        public static MustObjectAssertions Must(this object? subject)
        {
            return new MustObjectAssertions(subject);
        }
    }
}
