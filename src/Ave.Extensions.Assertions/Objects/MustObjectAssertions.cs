namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for general object values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustObjectAssertions : ObjectAssertionsBase<MustObjectAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustObjectAssertions"/> class.
        /// </summary>
        /// <param name="subject">The object value to assert on.</param>
        public MustObjectAssertions(object? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
