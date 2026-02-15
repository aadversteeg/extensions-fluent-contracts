using Ave.Extensions.FluentContracts;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for boolean contracts.
    /// </summary>
    public static class BooleanContractCodes
    {
        /// <summary>
        /// Root error code for boolean contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Boolean";

        /// <summary>
        /// Error code when BeTrue contract fails.
        /// </summary>
        public static readonly ErrorCode BeTrue = _ / "BeTrue";

        /// <summary>
        /// Error code when BeFalse contract fails.
        /// </summary>
        public static readonly ErrorCode BeFalse = _ / "BeFalse";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when Imply contract fails.
        /// </summary>
        public static readonly ErrorCode Imply = _ / "Imply";

        /// <summary>
        /// Error code when HaveValue contract fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";
    }
}
