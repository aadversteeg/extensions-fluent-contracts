using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for DateTimeOffset assertions.
    /// </summary>
    public static class DateTimeOffsetAssertionCodes
    {
        /// <summary>
        /// Root error code for DateTimeOffset assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "DateTimeOffset";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeCloseTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeCloseTo = _ / "BeCloseTo";

        /// <summary>
        /// Error code when NotBeCloseTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeCloseTo = _ / "NotBeCloseTo";

        /// <summary>
        /// Error code when BeBefore assertion fails.
        /// </summary>
        public static readonly ErrorCode BeBefore = _ / "BeBefore";

        /// <summary>
        /// Error code when BeOnOrBefore assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOnOrBefore = _ / "BeOnOrBefore";

        /// <summary>
        /// Error code when BeAfter assertion fails.
        /// </summary>
        public static readonly ErrorCode BeAfter = _ / "BeAfter";

        /// <summary>
        /// Error code when BeOnOrAfter assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOnOrAfter = _ / "BeOnOrAfter";

        /// <summary>
        /// Error code when HaveOffset assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveOffset = _ / "HaveOffset";

        /// <summary>
        /// Error code when NotHaveOffset assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveOffset = _ / "NotHaveOffset";

        /// <summary>
        /// Error code when HaveValue assertion fails (for nullable).
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue assertion fails (for nullable).
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";

        /// <summary>
        /// Error code when BeSameDateAs assertion fails.
        /// </summary>
        public static readonly ErrorCode BeSameDateAs = _ / "BeSameDateAs";
    }
}
