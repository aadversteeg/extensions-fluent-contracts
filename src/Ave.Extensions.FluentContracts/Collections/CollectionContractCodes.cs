using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for collection contracts.
    /// </summary>
    public static class CollectionContractCodes
    {
        /// <summary>
        /// Root error code for collection contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Collection";

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
        /// Error code when HaveCountGreaterThan contract fails.
        /// </summary>
        public static readonly ErrorCode HaveCountGreaterThan = _ / "HaveCountGreaterThan";

        /// <summary>
        /// Error code when HaveCountLessThan contract fails.
        /// </summary>
        public static readonly ErrorCode HaveCountLessThan = _ / "HaveCountLessThan";

        /// <summary>
        /// Error code when Contain contract fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain contract fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";

        /// <summary>
        /// Error code when ContainSingle contract fails.
        /// </summary>
        public static readonly ErrorCode ContainSingle = _ / "ContainSingle";

        /// <summary>
        /// Error code when OnlyContain contract fails.
        /// </summary>
        public static readonly ErrorCode OnlyContain = _ / "OnlyContain";

        /// <summary>
        /// Error code when BeSubsetOf contract fails.
        /// </summary>
        public static readonly ErrorCode BeSubsetOf = _ / "BeSubsetOf";

        /// <summary>
        /// Error code when NotBeSubsetOf contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeSubsetOf = _ / "NotBeSubsetOf";

        /// <summary>
        /// Error code when HaveElementAt contract fails.
        /// </summary>
        public static readonly ErrorCode HaveElementAt = _ / "HaveElementAt";

        /// <summary>
        /// Error code when AllSatisfy contract fails.
        /// </summary>
        public static readonly ErrorCode AllSatisfy = _ / "AllSatisfy";

        /// <summary>
        /// Error code when BeInAscendingOrder contract fails.
        /// </summary>
        public static readonly ErrorCode BeInAscendingOrder = _ / "BeInAscendingOrder";

        /// <summary>
        /// Error code when BeInDescendingOrder contract fails.
        /// </summary>
        public static readonly ErrorCode BeInDescendingOrder = _ / "BeInDescendingOrder";
    }
}
