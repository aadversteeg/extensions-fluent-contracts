using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for Enum contracts.
    /// </summary>
    public static class EnumContractCodes
    {
        /// <summary>
        /// Root error code for Enum contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Enum";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeDefined contract fails.
        /// </summary>
        public static readonly ErrorCode BeDefined = _ / "BeDefined";

        /// <summary>
        /// Error code when NotBeDefined contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeDefined = _ / "NotBeDefined";

        /// <summary>
        /// Error code when HaveValue contract fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";

        /// <summary>
        /// Error code when HaveSameValueAs contract fails.
        /// </summary>
        public static readonly ErrorCode HaveSameValueAs = _ / "HaveSameValueAs";

        /// <summary>
        /// Error code when NotHaveSameValueAs contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSameValueAs = _ / "NotHaveSameValueAs";

        /// <summary>
        /// Error code when HaveSameNameAs contract fails.
        /// </summary>
        public static readonly ErrorCode HaveSameNameAs = _ / "HaveSameNameAs";

        /// <summary>
        /// Error code when NotHaveSameNameAs contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSameNameAs = _ / "NotHaveSameNameAs";

        /// <summary>
        /// Error code when HaveFlag contract fails.
        /// </summary>
        public static readonly ErrorCode HaveFlag = _ / "HaveFlag";

        /// <summary>
        /// Error code when NotHaveFlag contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveFlag = _ / "NotHaveFlag";

        /// <summary>
        /// Error code when Match contract fails.
        /// </summary>
        public static readonly ErrorCode Match = _ / "Match";

        /// <summary>
        /// Error code when BeOneOf contract fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when BeNull contract fails (for nullable enums).
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull contract fails (for nullable enums).
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";
    }
}
