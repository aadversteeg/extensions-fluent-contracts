namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for string types.
    /// </summary>
    public static class StringContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="StringContracts"/> object for checking contracts on the specified string.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The string to check.</param>
        /// <returns>A <see cref="StringContracts"/> instance.</returns>
        public static StringContracts Should(this string? subject)
        {
            return new StringContracts(subject);
        }
    }
}
