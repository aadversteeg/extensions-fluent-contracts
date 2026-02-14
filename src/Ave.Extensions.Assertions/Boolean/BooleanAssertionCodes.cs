using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Boolean
{
    /// <summary>
    /// Error codes for boolean assertions.
    /// </summary>
    public static class BooleanAssertionCodes
    {
        /// <summary>
        /// Root error code for boolean assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Boolean";

        /// <summary>
        /// Error code when BeTrue assertion fails.
        /// </summary>
        public static readonly ErrorCode BeTrue = _ / "BeTrue";

        /// <summary>
        /// Error code when BeFalse assertion fails.
        /// </summary>
        public static readonly ErrorCode BeFalse = _ / "BeFalse";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when Imply assertion fails.
        /// </summary>
        public static readonly ErrorCode Imply = _ / "Imply";

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
