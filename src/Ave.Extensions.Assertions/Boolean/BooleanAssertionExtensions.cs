namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for boolean types.
    /// </summary>
    public static class BooleanAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="BooleanAssertions"/> object for asserting on the specified boolean value.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The boolean value to assert on.</param>
        /// <returns>A <see cref="BooleanAssertions"/> instance.</returns>
        public static BooleanAssertions Should(this bool subject)
        {
            return new BooleanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustBooleanAssertions"/> object for asserting on the specified boolean value.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The boolean value to assert on.</param>
        /// <returns>A <see cref="MustBooleanAssertions"/> instance.</returns>
        public static MustBooleanAssertions Must(this bool subject)
        {
            return new MustBooleanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="NullableBooleanAssertions"/> object for asserting on the specified nullable boolean value.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable boolean value to assert on.</param>
        /// <returns>A <see cref="NullableBooleanAssertions"/> instance.</returns>
        public static NullableBooleanAssertions Should(this bool? subject)
        {
            return new NullableBooleanAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableBooleanAssertions"/> object for asserting on the specified nullable boolean value.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable boolean value to assert on.</param>
        /// <returns>A <see cref="MustNullableBooleanAssertions"/> instance.</returns>
        public static MustNullableBooleanAssertions Must(this bool? subject)
        {
            return new MustNullableBooleanAssertions(subject);
        }
    }
}
