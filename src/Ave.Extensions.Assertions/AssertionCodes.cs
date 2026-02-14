using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Root error codes for assertions. Type-specific codes are defined in their respective namespaces.
    /// </summary>
    public static class AssertionCodes
    {
        /// <summary>
        /// The root assertion error code. All assertion error codes are children of this code.
        /// </summary>
        public static readonly ErrorCode _ = new ErrorCode("Assertion");
    }
}
