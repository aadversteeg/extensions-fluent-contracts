using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for DateTime assertions.
    /// </summary>
    public static class DateTimeAssertionCodes
    {
        /// <summary>
        /// Root error code for DateTime assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "DateTime";

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
        /// Error code when HaveYear assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveYear = _ / "HaveYear";

        /// <summary>
        /// Error code when NotHaveYear assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveYear = _ / "NotHaveYear";

        /// <summary>
        /// Error code when HaveMonth assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveMonth = _ / "HaveMonth";

        /// <summary>
        /// Error code when NotHaveMonth assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveMonth = _ / "NotHaveMonth";

        /// <summary>
        /// Error code when HaveDay assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveDay = _ / "HaveDay";

        /// <summary>
        /// Error code when NotHaveDay assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveDay = _ / "NotHaveDay";

        /// <summary>
        /// Error code when HaveHour assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveHour = _ / "HaveHour";

        /// <summary>
        /// Error code when NotHaveHour assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveHour = _ / "NotHaveHour";

        /// <summary>
        /// Error code when HaveMinute assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveMinute = _ / "HaveMinute";

        /// <summary>
        /// Error code when NotHaveMinute assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveMinute = _ / "NotHaveMinute";

        /// <summary>
        /// Error code when HaveSecond assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveSecond = _ / "HaveSecond";

        /// <summary>
        /// Error code when NotHaveSecond assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSecond = _ / "NotHaveSecond";

        /// <summary>
        /// Error code when BeSameDateAs assertion fails.
        /// </summary>
        public static readonly ErrorCode BeSameDateAs = _ / "BeSameDateAs";

        /// <summary>
        /// Error code when NotBeSameDateAs assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeSameDateAs = _ / "NotBeSameDateAs";

        /// <summary>
        /// Error code when BeOneOf assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when BeIn (DateTimeKind) assertion fails.
        /// </summary>
        public static readonly ErrorCode BeIn = _ / "BeIn";
    }
}
