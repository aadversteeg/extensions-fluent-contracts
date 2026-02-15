using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for exception contracts.
    /// </summary>
    public static class ExceptionContractCodes
    {
        /// <summary>
        /// Root error code for exception contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Exception";

        /// <summary>
        /// Error code when Throw contract fails.
        /// </summary>
        public static readonly ErrorCode Throw = _ / "Throw";

        /// <summary>
        /// Error code when NotThrow contract fails.
        /// </summary>
        public static readonly ErrorCode NotThrow = _ / "NotThrow";

        /// <summary>
        /// Error code when ThrowExactly contract fails.
        /// </summary>
        public static readonly ErrorCode ThrowExactly = _ / "ThrowExactly";

        /// <summary>
        /// Error code when HaveMessage contract fails.
        /// </summary>
        public static readonly ErrorCode HaveMessage = _ / "HaveMessage";

        /// <summary>
        /// Error code when HaveInnerException contract fails.
        /// </summary>
        public static readonly ErrorCode HaveInnerException = _ / "HaveInnerException";

        /// <summary>
        /// Error code when NotHaveInnerException contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveInnerException = _ / "NotHaveInnerException";

        /// <summary>
        /// Error code when ContainMessage contract fails.
        /// </summary>
        public static readonly ErrorCode ContainMessage = _ / "ContainMessage";

        /// <summary>
        /// Error code when BeOfType contract fails.
        /// </summary>
        public static readonly ErrorCode BeOfType = _ / "BeOfType";

        /// <summary>
        /// Error code when NotBeOfType contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeOfType = _ / "NotBeOfType";

        /// <summary>
        /// Error code when WithMessage contract fails (alias for HaveMessage).
        /// </summary>
        public static readonly ErrorCode WithMessage = _ / "WithMessage";

        /// <summary>
        /// Error code when WithInnerException contract fails (alias for HaveInnerException).
        /// </summary>
        public static readonly ErrorCode WithInnerException = _ / "WithInnerException";

        /// <summary>
        /// Error code when Where contract fails.
        /// </summary>
        public static readonly ErrorCode Where = _ / "Where";
    }
}
