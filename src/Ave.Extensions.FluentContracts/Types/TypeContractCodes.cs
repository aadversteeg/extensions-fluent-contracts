using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for Type contracts.
    /// </summary>
    public static class TypeContractCodes
    {
        /// <summary>
        /// Root error code for Type contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Type";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeAssignableTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeAssignableTo = _ / "BeAssignableTo";

        /// <summary>
        /// Error code when NotBeAssignableTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeAssignableTo = _ / "NotBeAssignableTo";

        /// <summary>
        /// Error code when BeDecoratedWith contract fails.
        /// </summary>
        public static readonly ErrorCode BeDecoratedWith = _ / "BeDecoratedWith";

        /// <summary>
        /// Error code when NotBeDecoratedWith contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeDecoratedWith = _ / "NotBeDecoratedWith";

        /// <summary>
        /// Error code when Implement contract fails.
        /// </summary>
        public static readonly ErrorCode Implement = _ / "Implement";

        /// <summary>
        /// Error code when NotImplement contract fails.
        /// </summary>
        public static readonly ErrorCode NotImplement = _ / "NotImplement";

        /// <summary>
        /// Error code when BeDerivedFrom contract fails.
        /// </summary>
        public static readonly ErrorCode BeDerivedFrom = _ / "BeDerivedFrom";

        /// <summary>
        /// Error code when NotBeDerivedFrom contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeDerivedFrom = _ / "NotBeDerivedFrom";

        /// <summary>
        /// Error code when BeSealed contract fails.
        /// </summary>
        public static readonly ErrorCode BeSealed = _ / "BeSealed";

        /// <summary>
        /// Error code when NotBeSealed contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeSealed = _ / "NotBeSealed";

        /// <summary>
        /// Error code when BeAbstract contract fails.
        /// </summary>
        public static readonly ErrorCode BeAbstract = _ / "BeAbstract";

        /// <summary>
        /// Error code when NotBeAbstract contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeAbstract = _ / "NotBeAbstract";

        /// <summary>
        /// Error code when HaveProperty contract fails.
        /// </summary>
        public static readonly ErrorCode HaveProperty = _ / "HaveProperty";

        /// <summary>
        /// Error code when NotHaveProperty contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveProperty = _ / "NotHaveProperty";

        /// <summary>
        /// Error code when HaveMethod contract fails.
        /// </summary>
        public static readonly ErrorCode HaveMethod = _ / "HaveMethod";

        /// <summary>
        /// Error code when NotHaveMethod contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveMethod = _ / "NotHaveMethod";

        /// <summary>
        /// Error code when BeInterface contract fails.
        /// </summary>
        public static readonly ErrorCode BeInterface = _ / "BeInterface";

        /// <summary>
        /// Error code when NotBeInterface contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeInterface = _ / "NotBeInterface";

        /// <summary>
        /// Error code when BeClass contract fails.
        /// </summary>
        public static readonly ErrorCode BeClass = _ / "BeClass";

        /// <summary>
        /// Error code when NotBeClass contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeClass = _ / "NotBeClass";

        /// <summary>
        /// Error code when HaveDefaultConstructor contract fails.
        /// </summary>
        public static readonly ErrorCode HaveDefaultConstructor = _ / "HaveDefaultConstructor";

        /// <summary>
        /// Error code when NotHaveDefaultConstructor contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveDefaultConstructor = _ / "NotHaveDefaultConstructor";
    }
}
