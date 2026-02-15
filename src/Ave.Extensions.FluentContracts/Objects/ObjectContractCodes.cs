using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for object contracts.
    /// </summary>
    public static class ObjectContractCodes
    {
        /// <summary>
        /// Root error code for object contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Object";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeNull contract fails.
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";

        /// <summary>
        /// Error code when BeSameAs contract fails.
        /// </summary>
        public static readonly ErrorCode BeSameAs = _ / "BeSameAs";

        /// <summary>
        /// Error code when NotBeSameAs contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeSameAs = _ / "NotBeSameAs";

        /// <summary>
        /// Error code when BeOfType contract fails.
        /// </summary>
        public static readonly ErrorCode BeOfType = _ / "BeOfType";

        /// <summary>
        /// Error code when NotBeOfType contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeOfType = _ / "NotBeOfType";

        /// <summary>
        /// Error code when BeAssignableTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeAssignableTo = _ / "BeAssignableTo";

        /// <summary>
        /// Error code when NotBeAssignableTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeAssignableTo = _ / "NotBeAssignableTo";

        /// <summary>
        /// Error code when Match contract fails.
        /// </summary>
        public static readonly ErrorCode Match = _ / "Match";
    }
}
