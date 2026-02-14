using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for Guid assertions.
    /// </summary>
    public static class GuidAssertionCodes
    {
        /// <summary>
        /// Root error code for Guid assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Guid";

        /// <summary>
        /// Error code when BeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when HaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";
    }
}
