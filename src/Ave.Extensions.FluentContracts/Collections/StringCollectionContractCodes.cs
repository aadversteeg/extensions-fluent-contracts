using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for string collection contracts.
    /// </summary>
    public static class StringCollectionContractCodes
    {
        /// <summary>
        /// Root error code for string collection contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "StringCollection";

        /// <summary>
        /// Error code when ContainMatch contract fails.
        /// </summary>
        public static readonly ErrorCode ContainMatch = _ / "ContainMatch";

        /// <summary>
        /// Error code when NotContainMatch contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainMatch = _ / "NotContainMatch";

        /// <summary>
        /// Error code when AllMatch contract fails.
        /// </summary>
        public static readonly ErrorCode AllMatch = _ / "AllMatch";

        /// <summary>
        /// Error code when ContainEquivalentOf contract fails.
        /// </summary>
        public static readonly ErrorCode ContainEquivalentOf = _ / "ContainEquivalentOf";

        /// <summary>
        /// Error code when NotContainEquivalentOf contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainEquivalentOf = _ / "NotContainEquivalentOf";

        /// <summary>
        /// Error code when OnlyContainNullOrEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode OnlyContainNullOrEmpty = _ / "OnlyContainNullOrEmpty";

        /// <summary>
        /// Error code when NotContainNullOrEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainNullOrEmpty = _ / "NotContainNullOrEmpty";

        /// <summary>
        /// Error code when Equal contract fails.
        /// </summary>
        public static readonly ErrorCode Equal = _ / "Equal";

        /// <summary>
        /// Error code when BeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when HaveCount contract fails.
        /// </summary>
        public static readonly ErrorCode HaveCount = _ / "HaveCount";

        /// <summary>
        /// Error code when Contain contract fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain contract fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";
    }
}
