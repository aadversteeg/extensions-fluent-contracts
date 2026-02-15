namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods for object contracts.
    /// </summary>
    public static class ObjectContractExtensions
    {
        /// <summary>
        /// Returns an <see cref="ObjectContracts"/> object for checking contracts on the specified object.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The object to check.</param>
        /// <returns>An <see cref="ObjectContracts"/> instance.</returns>
        public static ObjectContracts Should(this object? subject)
        {
            return new ObjectContracts(subject);
        }
    }
}
