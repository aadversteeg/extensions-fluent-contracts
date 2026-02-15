using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for Guid contracts.
    /// </summary>
    public static class GuidContractCodes
    {
        /// <summary>
        /// Root error code for Guid contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Guid";

        /// <summary>
        /// Error code when BeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

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
