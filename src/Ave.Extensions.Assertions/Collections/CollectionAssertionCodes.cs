using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Error codes for collection assertions.
    /// </summary>
    public static class CollectionAssertionCodes
    {
        /// <summary>
        /// Root error code for collection assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Collection";

        /// <summary>
        /// Error code when BeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when HaveCount assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveCount = _ / "HaveCount";

        /// <summary>
        /// Error code when HaveCountGreaterThan assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveCountGreaterThan = _ / "HaveCountGreaterThan";

        /// <summary>
        /// Error code when HaveCountLessThan assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveCountLessThan = _ / "HaveCountLessThan";

        /// <summary>
        /// Error code when Contain assertion fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";

        /// <summary>
        /// Error code when ContainSingle assertion fails.
        /// </summary>
        public static readonly ErrorCode ContainSingle = _ / "ContainSingle";

        /// <summary>
        /// Error code when OnlyContain assertion fails.
        /// </summary>
        public static readonly ErrorCode OnlyContain = _ / "OnlyContain";

        /// <summary>
        /// Error code when BeSubsetOf assertion fails.
        /// </summary>
        public static readonly ErrorCode BeSubsetOf = _ / "BeSubsetOf";

        /// <summary>
        /// Error code when NotBeSubsetOf assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeSubsetOf = _ / "NotBeSubsetOf";

        /// <summary>
        /// Error code when HaveElementAt assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveElementAt = _ / "HaveElementAt";

        /// <summary>
        /// Error code when AllSatisfy assertion fails.
        /// </summary>
        public static readonly ErrorCode AllSatisfy = _ / "AllSatisfy";

        /// <summary>
        /// Error code when BeInAscendingOrder assertion fails.
        /// </summary>
        public static readonly ErrorCode BeInAscendingOrder = _ / "BeInAscendingOrder";

        /// <summary>
        /// Error code when BeInDescendingOrder assertion fails.
        /// </summary>
        public static readonly ErrorCode BeInDescendingOrder = _ / "BeInDescendingOrder";
    }
}
