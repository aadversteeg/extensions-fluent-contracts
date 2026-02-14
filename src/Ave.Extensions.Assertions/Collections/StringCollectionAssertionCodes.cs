using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Collections
{
    /// <summary>
    /// Error codes for string collection assertions.
    /// </summary>
    public static class StringCollectionAssertionCodes
    {
        /// <summary>
        /// Root error code for string collection assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "StringCollection";

        /// <summary>
        /// Error code when ContainMatch assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainMatch = _ / "ContainMatch";

        /// <summary>
        /// Error code when NotContainMatch assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainMatch = _ / "NotContainMatch";

        /// <summary>
        /// Error code when AllMatch assertion fails.
        /// </summary>
        public static readonly ErrorCode AllMatch = _ / "AllMatch";

        /// <summary>
        /// Error code when ContainEquivalentOf assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainEquivalentOf = _ / "ContainEquivalentOf";

        /// <summary>
        /// Error code when NotContainEquivalentOf assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainEquivalentOf = _ / "NotContainEquivalentOf";

        /// <summary>
        /// Error code when OnlyContainNullOrEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode OnlyContainNullOrEmpty = _ / "OnlyContainNullOrEmpty";

        /// <summary>
        /// Error code when NotContainNullOrEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainNullOrEmpty = _ / "NotContainNullOrEmpty";

        /// <summary>
        /// Error code when Equal assertion fails.
        /// </summary>
        public static readonly ErrorCode Equal = _ / "Equal";

        /// <summary>
        /// Error code when BeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when HaveCount assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveCount = _ / "HaveCount";

        /// <summary>
        /// Error code when Contain assertion fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";
    }
}
