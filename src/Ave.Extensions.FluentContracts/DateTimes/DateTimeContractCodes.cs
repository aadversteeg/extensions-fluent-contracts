using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for DateTime contracts.
    /// </summary>
    public static class DateTimeContractCodes
    {
        /// <summary>
        /// Root error code for DateTime contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "DateTime";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeCloseTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeCloseTo = _ / "BeCloseTo";

        /// <summary>
        /// Error code when NotBeCloseTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeCloseTo = _ / "NotBeCloseTo";

        /// <summary>
        /// Error code when BeBefore contract fails.
        /// </summary>
        public static readonly ErrorCode BeBefore = _ / "BeBefore";

        /// <summary>
        /// Error code when BeOnOrBefore contract fails.
        /// </summary>
        public static readonly ErrorCode BeOnOrBefore = _ / "BeOnOrBefore";

        /// <summary>
        /// Error code when BeAfter contract fails.
        /// </summary>
        public static readonly ErrorCode BeAfter = _ / "BeAfter";

        /// <summary>
        /// Error code when BeOnOrAfter contract fails.
        /// </summary>
        public static readonly ErrorCode BeOnOrAfter = _ / "BeOnOrAfter";

        /// <summary>
        /// Error code when HaveYear contract fails.
        /// </summary>
        public static readonly ErrorCode HaveYear = _ / "HaveYear";

        /// <summary>
        /// Error code when NotHaveYear contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveYear = _ / "NotHaveYear";

        /// <summary>
        /// Error code when HaveMonth contract fails.
        /// </summary>
        public static readonly ErrorCode HaveMonth = _ / "HaveMonth";

        /// <summary>
        /// Error code when NotHaveMonth contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveMonth = _ / "NotHaveMonth";

        /// <summary>
        /// Error code when HaveDay contract fails.
        /// </summary>
        public static readonly ErrorCode HaveDay = _ / "HaveDay";

        /// <summary>
        /// Error code when NotHaveDay contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveDay = _ / "NotHaveDay";

        /// <summary>
        /// Error code when HaveHour contract fails.
        /// </summary>
        public static readonly ErrorCode HaveHour = _ / "HaveHour";

        /// <summary>
        /// Error code when NotHaveHour contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveHour = _ / "NotHaveHour";

        /// <summary>
        /// Error code when HaveMinute contract fails.
        /// </summary>
        public static readonly ErrorCode HaveMinute = _ / "HaveMinute";

        /// <summary>
        /// Error code when NotHaveMinute contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveMinute = _ / "NotHaveMinute";

        /// <summary>
        /// Error code when HaveSecond contract fails.
        /// </summary>
        public static readonly ErrorCode HaveSecond = _ / "HaveSecond";

        /// <summary>
        /// Error code when NotHaveSecond contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveSecond = _ / "NotHaveSecond";

        /// <summary>
        /// Error code when BeSameDateAs contract fails.
        /// </summary>
        public static readonly ErrorCode BeSameDateAs = _ / "BeSameDateAs";

        /// <summary>
        /// Error code when NotBeSameDateAs contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeSameDateAs = _ / "NotBeSameDateAs";

        /// <summary>
        /// Error code when BeOneOf contract fails.
        /// </summary>
        public static readonly ErrorCode BeOneOf = _ / "BeOneOf";

        /// <summary>
        /// Error code when BeIn (DateTimeKind) contract fails.
        /// </summary>
        public static readonly ErrorCode BeIn = _ / "BeIn";
    }
}
