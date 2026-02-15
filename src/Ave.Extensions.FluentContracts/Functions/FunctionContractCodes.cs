using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for function contracts.
    /// </summary>
    public static class FunctionContractCodes
    {
        /// <summary>
        /// Root error code for function contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Function";

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
        /// Error code when Return contract fails.
        /// </summary>
        public static readonly ErrorCode Return = _ / "Return";

        /// <summary>
        /// Error code when NotReturn contract fails.
        /// </summary>
        public static readonly ErrorCode NotReturn = _ / "NotReturn";

        /// <summary>
        /// Error code when ReturnNotNull contract fails.
        /// </summary>
        public static readonly ErrorCode ReturnNotNull = _ / "ReturnNotNull";

        /// <summary>
        /// Error code when ReturnNull contract fails.
        /// </summary>
        public static readonly ErrorCode ReturnNull = _ / "ReturnNull";

        /// <summary>
        /// Error code when Satisfy contract fails.
        /// </summary>
        public static readonly ErrorCode Satisfy = _ / "Satisfy";
    }
}
