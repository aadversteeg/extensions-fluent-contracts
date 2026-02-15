using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for IComparable contracts.
    /// </summary>
    public static class ComparableContractCodes
    {
        /// <summary>
        /// Root error code for Comparable contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Comparable";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeGreaterThan contract fails.
        /// </summary>
        public static readonly ErrorCode BeGreaterThan = _ / "BeGreaterThan";

        /// <summary>
        /// Error code when BeGreaterThanOrEqualTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeGreaterThanOrEqualTo = _ / "BeGreaterThanOrEqualTo";

        /// <summary>
        /// Error code when BeLessThan contract fails.
        /// </summary>
        public static readonly ErrorCode BeLessThan = _ / "BeLessThan";

        /// <summary>
        /// Error code when BeLessThanOrEqualTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeLessThanOrEqualTo = _ / "BeLessThanOrEqualTo";

        /// <summary>
        /// Error code when BeInRange contract fails.
        /// </summary>
        public static readonly ErrorCode BeInRange = _ / "BeInRange";

        /// <summary>
        /// Error code when NotBeInRange contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeInRange = _ / "NotBeInRange";

        /// <summary>
        /// Error code when BeOneOf contract fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when BeRankedEquallyTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeRankedEquallyTo = _ / "BeRankedEquallyTo";

        /// <summary>
        /// Error code when NotBeRankedEquallyTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeRankedEquallyTo = _ / "NotBeRankedEquallyTo";

        /// <summary>
        /// Error code when HaveValue contract fails (for nullable).
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue contract fails (for nullable).
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";
    }
}
