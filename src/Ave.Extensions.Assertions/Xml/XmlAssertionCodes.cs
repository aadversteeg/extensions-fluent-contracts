using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions.Xml
{
    /// <summary>
    /// Error codes for XML assertions.
    /// </summary>
    public static class XmlAssertionCodes
    {
        /// <summary>
        /// Root error code for XML assertions.
        /// </summary>
        public static readonly ErrorCode _ = AssertionCodes._ / "Xml";

        /// <summary>
        /// Error code when Be assertion fails.
        /// </summary>
        public static readonly ErrorCode Be = _ / "Be";

        /// <summary>
        /// Error code when NotBe assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBe = _ / "NotBe";

        /// <summary>
        /// Error code when BeEquivalentTo assertion fails.
        /// </summary>
        public static readonly ErrorCode BeEquivalentTo = _ / "BeEquivalentTo";

        /// <summary>
        /// Error code when NotBeEquivalentTo assertion fails.
        /// </summary>
        public static readonly ErrorCode NotBeEquivalentTo = _ / "NotBeEquivalentTo";

        /// <summary>
        /// Error code when HaveRoot assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveRoot = _ / "HaveRoot";

        /// <summary>
        /// Error code when HaveElement assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveElement = _ / "HaveElement";

        /// <summary>
        /// Error code when HaveValue assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveValue = _ / "HaveValue";

        /// <summary>
        /// Error code when HaveAttribute assertion fails.
        /// </summary>
        public static readonly ErrorCode HaveAttribute = _ / "HaveAttribute";
    }
}
