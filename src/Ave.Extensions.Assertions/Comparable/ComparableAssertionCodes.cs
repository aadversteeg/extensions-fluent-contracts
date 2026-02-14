using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Comparable
{
    /// <summary>
    /// Error codes for IComparable assertions.
    /// </summary>
    public static class ComparableAssertionCodes
    {
        /// <summary>
        /// Root error code for Comparable assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Comparable";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

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
        /// Error code when BeRankedEquallyTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeRankedEquallyTo = _ / "BeRankedEquallyTo";

        /// <summary>
        /// Error code when NotBeRankedEquallyTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeRankedEquallyTo = _ / "NotBeRankedEquallyTo";

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
