using System;

namespace Ave.Extensions.Assertions.Guids
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for Guid types.
    /// </summary>
    public static class GuidAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="GuidAssertions"/> object for asserting on the specified Guid.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Guid to assert on.</param>
        /// <returns>A <see cref="GuidAssertions"/> instance.</returns>
        public static GuidAssertions Should(this Guid subject)
        {
            return new GuidAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustGuidAssertions"/> object for asserting on the specified Guid.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The Guid to assert on.</param>
        /// <returns>A <see cref="MustGuidAssertions"/> instance.</returns>
        public static MustGuidAssertions Must(this Guid subject)
        {
            return new MustGuidAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="NullableGuidAssertions"/> object for asserting on the specified nullable Guid.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable Guid to assert on.</param>
        /// <returns>A <see cref="NullableGuidAssertions"/> instance.</returns>
        public static NullableGuidAssertions Should(this Guid? subject)
        {
            return new NullableGuidAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableGuidAssertions"/> object for asserting on the specified nullable Guid.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable Guid to assert on.</param>
        /// <returns>A <see cref="MustNullableGuidAssertions"/> instance.</returns>
        public static MustNullableGuidAssertions Must(this Guid? subject)
        {
            return new MustNullableGuidAssertions(subject);
        }
    }
}
