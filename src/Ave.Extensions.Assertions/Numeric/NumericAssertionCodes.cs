using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Numeric
{
    /// <summary>
    /// Error codes for numeric assertions.
    /// </summary>
    public static class NumericAssertionCodes
    {
        /// <summary>
        /// Root error code for numeric assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Numeric";

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
        /// Error code when BeInRange assertion fails.
        /// </summary>
        public static readonly ErrorCode BeInRange = _ / "BeInRange";

        /// <summary>
        /// Error code when NotBeInRange assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeInRange = _ / "NotBeInRange";

        /// <summary>
        /// Error code when BeOneOf assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when Match assertion fails.
        /// </summary>
        public static readonly ErrorCode Match = _ / "Match";

        /// <summary>
        /// Error code when HaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";
    }
}
