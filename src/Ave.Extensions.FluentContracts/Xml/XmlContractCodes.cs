using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Error codes for XML contracts.
    /// </summary>
    public static class XmlContractCodes
    {
        /// <summary>
        /// Root error code for XML contracts.
        /// </summary>
        public static readonly ErrorCode _ = ContractCodes._ / "Xml";

        /// <summary>
        /// Error code when BeNull contract fails.
        /// </summary>
        public static readonly ErrorCode BeNull = _ / "BeNull";

        /// <summary>
        /// Error code when NotBeNull contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeNull = _ / "NotBeNull";

        /// <summary>
        /// Error code when HaveValue contract fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when HaveName contract fails.
        /// </summary>
        public static readonly ErrorCode HaveName = _ / "HaveName";

        /// <summary>
        /// Error code when HaveAttribute contract fails.
        /// </summary>
        public static readonly ErrorCode HaveAttribute = _ / "HaveAttribute";

        /// <summary>
        /// Error code when NotHaveAttribute contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveAttribute = _ / "NotHaveAttribute";

        /// <summary>
        /// Error code when HaveElement contract fails.
        /// </summary>
        public static readonly ErrorCode HaveElement = _ / "HaveElement";

        /// <summary>
        /// Error code when NotHaveElement contract fails.
        /// </summary>
        public static readonly ErrorCode NotHaveElement = _ / "NotHaveElement";

        /// <summary>
        /// Error code when HaveRoot contract fails.
        /// </summary>
        public static readonly ErrorCode HaveRoot = _ / "HaveRoot";

        /// <summary>
        /// Error code when HaveDeclaration contract fails.
        /// </summary>
        public static readonly ErrorCode HaveDeclaration = _ / "HaveDeclaration";

        /// <summary>
        /// Error code when BeEquivalentTo contract fails.
        /// </summary>
        public static readonly ErrorCode BeEquivalentTo = _ / "BeEquivalentTo";

        /// <summary>
        /// Error code when NotBeEquivalentTo contract fails.
        /// </summary>
        public static readonly ErrorCode NotBeEquivalentTo = _ / "NotBeEquivalentTo";

        /// <summary>
        /// Error code when Be contract fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe contract fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";
    }
}
