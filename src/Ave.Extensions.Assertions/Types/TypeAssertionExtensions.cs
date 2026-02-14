using System;

namespace Ave.Extensions.Assertions.Types
{
    /// <summary>
    /// Extension methods for Type assertions.
    /// </summary>
    public static class TypeAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="TypeAssertions"/> object for asserting on the specified Type.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Type to assert on.</param>
        /// <returns>A <see cref="TypeAssertions"/> instance.</returns>
        public static TypeAssertions Should(this Type? subject)
        {
            return new TypeAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustTypeAssertions"/> object for asserting on the specified Type.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The Type to assert on.</param>
        /// <returns>A <see cref="MustTypeAssertions"/> instance.</returns>
        public static MustTypeAssertions Must(this Type? subject)
        {
            return new MustTypeAssertions(subject);
        }
    }
}
