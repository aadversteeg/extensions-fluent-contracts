namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for nullable boolean values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustNullableBooleanAssertions : NullableBooleanAssertionsBase<MustNullableBooleanAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableBooleanAssertions"/> class.
        /// </summary>
        /// <param name="subject">The nullable boolean value to assert on.</param>
        public MustNullableBooleanAssertions(bool? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
