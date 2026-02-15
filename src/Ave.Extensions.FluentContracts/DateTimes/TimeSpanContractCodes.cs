using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for TimeSpan contracts.
    /// </summary>
    public static class TimeSpanContractCodes
    {
        /// <summary>
        /// Root error code for TimeSpan contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "TimeSpan";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BePositive contract fails.
        /// </summary>
        public static readonly ErrorCode BePositive = _ / "BePositive";

        /// <summary>
        /// Error code when BeNegative contract fails.
        /// </summary>
        public static readonly ErrorCode BeNegative = _ / "BeNegative";

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
        /// Error code when BeCloseTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeCloseTo = _ / "BeCloseTo";

        /// <summary>
        /// Error code when NotBeCloseTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeCloseTo = _ / "NotBeCloseTo";

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
