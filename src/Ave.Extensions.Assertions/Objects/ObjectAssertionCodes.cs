using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Objects
{
    /// <summary>
    /// Error codes for object assertions.
    /// </summary>
    public static class ObjectAssertionCodes
    {
        /// <summary>
        /// Root error code for object assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Object";

        /// <summary>
        /// Error code when BeNull assertion fails.
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";

        /// <summary>
        /// Error code when Be (equality) assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe (inequality) assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeSameAs (reference equality) assertion fails.
        /// </summary>
        public static readonly ErrorCode BeSameAs = _ / "BeSameAs";

        /// <summary>
        /// Error code when NotBeSameAs (reference inequality) assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeSameAs = _ / "NotBeSameAs";

        /// <summary>
        /// Error code when BeOfType assertion fails.
        /// </summary>
        public static readonly ErrorCode BeOfType = _ / "BeOfType";

        /// <summary>
        /// Error code when NotBeOfType assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeOfType = _ / "NotBeOfType";

        /// <summary>
        /// Error code when BeAssignableTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeAssignableTo = _ / "BeAssignableTo";

        /// <summary>
        /// Error code when NotBeAssignableTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeAssignableTo = _ / "NotBeAssignableTo";

        /// <summary>
        /// Error code when Match assertion fails.
        /// </summary>
        public static readonly ErrorCode Match = _ / "Match";
    }
}
