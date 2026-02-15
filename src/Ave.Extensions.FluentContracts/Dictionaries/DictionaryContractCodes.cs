using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for dictionary contracts.
    /// </summary>
    public static class DictionaryContractCodes
    {
        /// <summary>
        /// Root error code for dictionary contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Dictionary";

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
        /// Error code when ContainKey contract fails.
        /// </summary>
        public static readonly ErrorCode ContainKey = _ / "ContainKey";

        /// <summary>
        /// Error code when NotContainKey contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainKey = _ / "NotContainKey";

        /// <summary>
        /// Error code when ContainValue contract fails.
        /// </summary>
        public static readonly ErrorCode ContainValue = _ / "ContainValue";

        /// <summary>
        /// Error code when NotContainValue contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainValue = _ / "NotContainValue";

        /// <summary>
        /// Error code when ContainKeyValuePair contract fails.
        /// </summary>
        public static readonly ErrorCode ContainKeyValuePair = _ / "ContainKeyValuePair";

        /// <summary>
        /// Error code when NotContainKeyValuePair contract fails.
        /// </summary>
        public static readonly ErrorCode NotContainKeyValuePair = _ / "NotContainKeyValuePair";

        /// <summary>
        /// Error code when ContainKeys contract fails.
        /// </summary>
        public static readonly ErrorCode ContainKeys = _ / "ContainKeys";

        /// <summary>
        /// Error code when HaveSameCount contract fails.
        /// </summary>
        public static readonly ErrorCode HaveSameCount = _ / "HaveSameCount";

        /// <summary>
        /// Error code when BeNull contract fails.
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";
    }
}
