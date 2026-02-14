using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for Enum assertions.
    /// </summary>
    public static class EnumAssertionCodes
    {
        /// <summary>
        /// Root error code for Enum assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Enum";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeDefined assertion fails.
        /// </summary>
        public static readonly ErrorCode BeDefined = _ / "BeDefined";

        /// <summary>
        /// Error code when NotBeDefined assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeDefined = _ / "NotBeDefined";

        /// <summary>
        /// Error code when HaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";

        /// <summary>
        /// Error code when HaveSameValueAs assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveSameValueAs = _ / "HaveSameValueAs";

        /// <summary>
        /// Error code when NotHaveSameValueAs assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSameValueAs = _ / "NotHaveSameValueAs";

        /// <summary>
        /// Error code when HaveSameNameAs assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveSameNameAs = _ / "HaveSameNameAs";

        /// <summary>
        /// Error code when NotHaveSameNameAs assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSameNameAs = _ / "NotHaveSameNameAs";

        /// <summary>
        /// Error code when HaveFlag assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveFlag = _ / "HaveFlag";

        /// <summary>
        /// Error code when NotHaveFlag assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveFlag = _ / "NotHaveFlag";

        /// <summary>
        /// Error code when Match assertion fails.
        /// </summary>
        public static readonly ErrorCode Match = _ / "Match";

        /// <summary>
        /// Error code when BeOneOf assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when BeNull assertion fails (for nullable enums).
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull assertion fails (for nullable enums).
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";
    }
}
