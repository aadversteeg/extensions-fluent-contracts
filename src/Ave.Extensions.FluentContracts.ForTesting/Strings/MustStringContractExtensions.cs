namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for string types.
    /// </summary>
    public static class MustStringContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustStringContracts"/> object for checking contracts on the specified string value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The string value to check.</param>
        /// <returns>A <see cref="MustStringContracts"/> instance.</returns>
        public static MustStringContracts Must(this string? subject)
        {
            return new MustStringContracts(subject);
        }
    }
}
