using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Root error codes for contracts. Type-specific codes are defined in their respective namespaces.
    /// </summary>
    public static class ContractCodes
    {
        /// <summary>
        /// The root contract error code. All contract error codes are children of this code.
        /// </summary>
        public static readonly ErrorCode _ = new ErrorCode("Contract");
    }
}
