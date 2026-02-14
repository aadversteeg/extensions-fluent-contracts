using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Strings
{
    /// <summary>
    /// Error codes for string assertions.
    /// </summary>
    public static class StringAssertionCodes
    {
        /// <summary>
        /// Root error code for string assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "String";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode BeEmpty = _ / "BeEmpty";

        /// <summary>
        /// Error code when NotBeEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeEmpty = _ / "NotBeEmpty";

        /// <summary>
        /// Error code when BeNullOrEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode BeNullOrEmpty = _ / "BeNullOrEmpty";

        /// <summary>
        /// Error code when NotBeNullOrEmpty assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeNullOrEmpty = _ / "NotBeNullOrEmpty";

        /// <summary>
        /// Error code when BeNullOrWhiteSpace assertion fails.
        /// </summary>
        public static readonly ErrorCode BeNullOrWhiteSpace = _ / "BeNullOrWhiteSpace";

        /// <summary>
        /// Error code when NotBeNullOrWhiteSpace assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeNullOrWhiteSpace = _ / "NotBeNullOrWhiteSpace";

        /// <summary>
        /// Error code when HaveLength assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveLength = _ / "HaveLength";

        /// <summary>
        /// Error code when StartWith assertion fails.
        /// </summary>
        public static readonly ErrorCode StartWith = _ / "StartWith";

        /// <summary>
        /// Error code when NotStartWith assertion fails.
        /// </summary>
        public static readonly ErrorCode NotStartWith = _ / "NotStartWith";

        /// <summary>
        /// Error code when EndWith assertion fails.
        /// </summary>
        public static readonly ErrorCode EndWith = _ / "EndWith";

        /// <summary>
        /// Error code when NotEndWith assertion fails.
        /// </summary>
        public static readonly ErrorCode NotEndWith = _ / "NotEndWith";

        /// <summary>
        /// Error code when Contain assertion fails.
        /// </summary>
        public static readonly ErrorCode Contain = _ / "Contain";

        /// <summary>
        /// Error code when NotContain assertion fails.
        /// </summary>
        public static readonly ErrorCode NotContain = _ / "NotContain";

        /// <summary>
        /// Error code when MatchRegex assertion fails.
        /// </summary>
        public static readonly ErrorCode MatchRegex = _ / "MatchRegex";

        /// <summary>
        /// Error code when NotMatchRegex assertion fails.
        /// </summary>
        public static readonly ErrorCode NotMatchRegex = _ / "NotMatchRegex";

        /// <summary>
        /// Error code when BeUpperCased assertion fails.
        /// </summary>
        public static readonly ErrorCode BeUpperCased = _ / "BeUpperCased";

        /// <summary>
        /// Error code when BeLowerCased assertion fails.
        /// </summary>
        public static readonly ErrorCode BeLowerCased = _ / "BeLowerCased";

        /// <summary>
        /// Error code when NotBeUpperCased assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeUpperCased = _ / "NotBeUpperCased";

        /// <summary>
        /// Error code when NotBeLowerCased assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeLowerCased = _ / "NotBeLowerCased";
    }
}
