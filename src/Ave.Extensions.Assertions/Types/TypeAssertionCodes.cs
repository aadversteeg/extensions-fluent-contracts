using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Types
{
    /// <summary>
    /// Error codes for Type assertions.
    /// </summary>
    public static class TypeAssertionCodes
    {
        /// <summary>
        /// Root error code for Type assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Type";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeAssignableTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeAssignableTo = _ / "BeAssignableTo";

        /// <summary>
        /// Error code when NotBeAssignableTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeAssignableTo = _ / "NotBeAssignableTo";

        /// <summary>
        /// Error code when Implement assertion fails.
        /// </summary>
        public static readonly ErrorCode Implement = _ / "Implement";

        /// <summary>
        /// Error code when NotImplement assertion fails.
        /// </summary>
        public static readonly ErrorCode NotImplement = _ / "NotImplement";

        /// <summary>
        /// Error code when BeDerivedFrom assertion fails.
        /// </summary>
        public static readonly ErrorCode BeDerivedFrom = _ / "BeDerivedFrom";

        /// <summary>
        /// Error code when NotBeDerivedFrom assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeDerivedFrom = _ / "NotBeDerivedFrom";

        /// <summary>
        /// Error code when BeSealed assertion fails.
        /// </summary>
        public static readonly ErrorCode BeSealed = _ / "BeSealed";

        /// <summary>
        /// Error code when NotBeSealed assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeSealed = _ / "NotBeSealed";

        /// <summary>
        /// Error code when BeAbstract assertion fails.
        /// </summary>
        public static readonly ErrorCode BeAbstract = _ / "BeAbstract";

        /// <summary>
        /// Error code when NotBeAbstract assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeAbstract = _ / "NotBeAbstract";

        /// <summary>
        /// Error code when BeInterface assertion fails.
        /// </summary>
        public static readonly ErrorCode BeInterface = _ / "BeInterface";

        /// <summary>
        /// Error code when NotBeInterface assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeInterface = _ / "NotBeInterface";

        /// <summary>
        /// Error code when BeClass assertion fails.
        /// </summary>
        public static readonly ErrorCode BeClass = _ / "BeClass";

        /// <summary>
        /// Error code when NotBeClass assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeClass = _ / "NotBeClass";

        /// <summary>
        /// Error code when BeDecoratedWith assertion fails.
        /// </summary>
        public static readonly ErrorCode BeDecoratedWith = _ / "BeDecoratedWith";

        /// <summary>
        /// Error code when NotBeDecoratedWith assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeDecoratedWith = _ / "NotBeDecoratedWith";

        /// <summary>
        /// Error code when HaveDefaultConstructor assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveDefaultConstructor = _ / "HaveDefaultConstructor";

        /// <summary>
        /// Error code when NotHaveDefaultConstructor assertion fails.
        /// </summary>
        public static readonly ErrorCode NotHaveDefaultConstructor = _ / "NotHaveDefaultConstructor";
    }
}
