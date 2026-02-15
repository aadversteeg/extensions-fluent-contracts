namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for object types.
    /// </summary>
    public static class MustObjectContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustObjectContracts"/> object for checking contracts on the specified object value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The object value to check.</param>
        /// <returns>A <see cref="MustObjectContracts"/> instance.</returns>
        public static MustObjectContracts Must(this object? subject)
        {
            return new MustObjectContracts(subject);
        }
    }
}
