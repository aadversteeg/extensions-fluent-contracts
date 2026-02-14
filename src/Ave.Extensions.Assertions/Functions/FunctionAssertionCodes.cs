using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for function assertions.
    /// </summary>
    public static class FunctionAssertionCodes
    {
        /// <summary>
        /// Root error code for function assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Function";

        /// <summary>
        /// Error code when NotThrow assertion fails.
        /// </summary>
        public static readonly ErrorCode NotThrow = _ / "NotThrow";

        /// <summary>
        /// Error code when Throw assertion fails.
        /// </summary>
        public static readonly ErrorCode Throw = _ / "Throw";

        /// <summary>
        /// Error code when ThrowExactly assertion fails.
        /// </summary>
        public static readonly ErrorCode ThrowExactly = _ / "ThrowExactly";

        /// <summary>
        /// Error code when Return assertion fails.
        /// </summary>
        public static readonly ErrorCode Return = _ / "Return";

        /// <summary>
        /// Error code when NotReturn assertion fails.
        /// </summary>
        public static readonly ErrorCode NotReturn = _ / "NotReturn";

        /// <summary>
        /// Error code when ReturnNotNull assertion fails.
        /// </summary>
        public static readonly ErrorCode ReturnNotNull = _ / "ReturnNotNull";

        /// <summary>
        /// Error code when ReturnNull assertion fails.
        /// </summary>
        public static readonly ErrorCode ReturnNull = _ / "ReturnNull";

        /// <summary>
        /// Error code when Satisfy assertion fails.
        /// </summary>
        public static readonly ErrorCode Satisfy = _ / "Satisfy";
    }
}
