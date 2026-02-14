using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for Exception assertions.
    /// </summary>
    public static class ExceptionAssertionCodes
    {
        /// <summary>
        /// Root error code for Exception assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Exception";

        /// <summary>
        /// Error code when Throw assertion fails (no exception thrown).
        /// </summary>
        public static readonly ErrorCode Throw = _ / "Throw";

        /// <summary>
        /// Error code when ThrowExactly assertion fails (wrong exception type).
        /// </summary>
        public static readonly ErrorCode ThrowExactly = _ / "ThrowExactly";

        /// <summary>
        /// Error code when NotThrow assertion fails (exception thrown).
        /// </summary>
        public static readonly ErrorCode NotThrow = _ / "NotThrow";

        /// <summary>
        /// Error code when WithMessage assertion fails.
        /// </summary>
        public static readonly ErrorCode WithMessage = _ / "WithMessage";

        /// <summary>
        /// Error code when WithInnerException assertion fails.
        /// </summary>
        public static readonly ErrorCode WithInnerException = _ / "WithInnerException";

        /// <summary>
        /// Error code when Where assertion fails.
        /// </summary>
        public static readonly ErrorCode Where = _ / "Where";
    }
}
