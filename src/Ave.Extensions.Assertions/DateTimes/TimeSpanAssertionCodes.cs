using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.DateTimes
{
    /// <summary>
    /// Error codes for TimeSpan assertions.
    /// </summary>
    public static class TimeSpanAssertionCodes
    {
        /// <summary>
        /// Root error code for TimeSpan assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "TimeSpan";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BePositive assertion fails.
        /// </summary>
        public static readonly ErrorCode BePositive = _ / "BePositive";

        /// <summary>
        /// Error code when BeNegative assertion fails.
        /// </summary>
        public static readonly ErrorCode BeNegative = _ / "BeNegative";

        /// <summary>
        /// Error code when BeGreaterThan assertion fails.
        /// </summary>
        public static readonly ErrorCode BeGreaterThan = _ / "BeGreaterThan";

        /// <summary>
        /// Error code when BeGreaterThanOrEqualTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeGreaterThanOrEqualTo = _ / "BeGreaterThanOrEqualTo";

        /// <summary>
        /// Error code when BeLessThan assertion fails.
        /// </summary>
        public static readonly ErrorCode BeLessThan = _ / "BeLessThan";

        /// <summary>
        /// Error code when BeLessThanOrEqualTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeLessThanOrEqualTo = _ / "BeLessThanOrEqualTo";

        /// <summary>
        /// Error code when BeCloseTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeCloseTo = _ / "BeCloseTo";

        /// <summary>
        /// Error code when NotBeCloseTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeCloseTo = _ / "NotBeCloseTo";

        /// <summary>
        /// Error code when HaveValue assertion fails (for nullable).
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue assertion fails (for nullable).
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";
    }
}
