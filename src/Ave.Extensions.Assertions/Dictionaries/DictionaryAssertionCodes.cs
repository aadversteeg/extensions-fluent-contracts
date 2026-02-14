using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for dictionary assertions.
    /// </summary>
    public static class DictionaryAssertionCodes
    {
        /// <summary>
        /// Root error code for dictionary assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Dictionary";

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
        /// Error code when ContainKey assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainKey = _ / "ContainKey";

        /// <summary>
        /// Error code when NotContainKey assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainKey = _ / "NotContainKey";

        /// <summary>
        /// Error code when ContainValue assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainValue = _ / "ContainValue";

        /// <summary>
        /// Error code when NotContainValue assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainValue = _ / "NotContainValue";

        /// <summary>
        /// Error code when ContainKeyValuePair assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainKeyValuePair = _ / "ContainKeyValuePair";

        /// <summary>
        /// Error code when NotContainKeyValuePair assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContainKeyValuePair = _ / "NotContainKeyValuePair";

        /// <summary>
        /// Error code when ContainKeys assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainKeys = _ / "ContainKeys";

        /// <summary>
        /// Error code when HaveSameCount assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveSameCount = _ / "HaveSameCount";

        /// <summary>
        /// Error code when BeNull assertion fails.
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";
    }
}
