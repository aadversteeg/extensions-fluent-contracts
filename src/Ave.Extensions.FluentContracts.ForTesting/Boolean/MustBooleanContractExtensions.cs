namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for boolean types.
    /// </summary>
    public static class MustBooleanContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustBooleanContracts"/> object for checking contracts on the specified boolean value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The boolean value to check.</param>
        /// <returns>A <see cref="MustBooleanContracts"/> instance.</returns>
        public static MustBooleanContracts Must(this bool subject)
        {
            return new MustBooleanContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableBooleanContracts"/> object for checking contracts on the specified nullable boolean value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable boolean value to check.</param>
        /// <returns>A <see cref="MustNullableBooleanContracts"/> instance.</returns>
        public static MustNullableBooleanContracts Must(this bool? subject)
        {
            return new MustNullableBooleanContracts(subject);
        }
    }
}
