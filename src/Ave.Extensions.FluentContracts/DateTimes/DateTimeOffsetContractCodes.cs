using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for DateTimeOffset contracts.
    /// </summary>
    public static class DateTimeOffsetContractCodes
    {
        /// <summary>
        /// Root error code for DateTimeOffset contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "DateTimeOffset";

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
        /// Error code when HaveOffset contract fails.
        /// </summary>
        public static readonly ErrorCode HaveOffset = _ / "HaveOffset";

        /// <summary>
        /// Error code when NotHaveOffset contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveOffset = _ / "NotHaveOffset";

        /// <summary>
        /// Error code when HaveValue contract fails (for nullable).
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when NotHaveValue contract fails (for nullable).
        /// </summary>
        public static readonly ErrorCode NotHaveValue = _ / "NotHaveValue";

        /// <summary>
        /// Error code when BeSameDateAs contract fails.
        /// </summary>
        public static readonly ErrorCode BeSameDateAs = _ / "BeSameDateAs";
    }
}
