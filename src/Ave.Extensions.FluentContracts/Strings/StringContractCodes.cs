using Ave.Extensions.FluentContracts;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for string contracts.
    /// </summary>
    public static class StringContractCodes
    {
        /// <summary>
        /// Root error code for string contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "String";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when BeNullOrEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode BeNullOrEmpty = _ / "BeNullOrEmpty";

        /// <summary>
        /// Error code when NotBeNullOrEmpty contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeNullOrEmpty = _ / "NotBeNullOrEmpty";

        /// <summary>
        /// Error code when BeNullOrWhiteSpace contract fails.
        /// </summary>
        public static readonly ErrorCode BeNullOrWhiteSpace = _ / "BeNullOrWhiteSpace";

        /// <summary>
        /// Error code when NotBeNullOrWhiteSpace contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeNullOrWhiteSpace = _ / "NotBeNullOrWhiteSpace";

        /// <summary>
        /// Error code when HaveLength contract fails.
        /// </summary>
        public static readonly ErrorCode HaveLength = _ / "HaveLength";

        /// <summary>
        /// Error code when StartWith contract fails.
        /// </summary>
        public static readonly ErrorCode StartWith = _ / "StartWith";

        /// <summary>
        /// Error code when NotStartWith contract fails.
        /// </summary>
        public static readonly ErrorCode NotStartWith = _ / "NotStartWith";

        /// <summary>
        /// Error code when EndWith contract fails.
        /// </summary>
        public static readonly ErrorCode EndWith = _ / "EndWith";

        /// <summary>
        /// Error code when NotEndWith contract fails.
        /// </summary>
        public static readonly ErrorCode NotEndWith = _ / "NotEndWith";

        /// <summary>
        /// Error code when Contain contract fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain contract fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";

        /// <summary>
        /// Error code when MatchRegex contract fails.
        /// </summary>
        public static readonly ErrorCode MatchRegex = _ / "MatchRegex";

        /// <summary>
        /// Error code when NotMatchRegex contract fails.
        /// </summary>
        public static readonly ErrorCode NotMatchRegex = _ / "NotMatchRegex";

        /// <summary>
        /// Error code when BeUpperCased contract fails.
        /// </summary>
        public static readonly ErrorCode BeUpperCased = _ / "BeUpperCased";

        /// <summary>
        /// Error code when BeLowerCased contract fails.
        /// </summary>
        public static readonly ErrorCode BeLowerCased = _ / "BeLowerCased";

        /// <summary>
        /// Error code when NotBeUpperCased contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeUpperCased = _ / "NotBeUpperCased";

        /// <summary>
        /// Error code when NotBeLowerCased contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeLowerCased = _ / "NotBeLowerCased";
    }
}
