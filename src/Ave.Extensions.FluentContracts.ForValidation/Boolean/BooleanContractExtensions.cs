namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for boolean types.
    /// </summary>
    public static class BooleanContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="BooleanContracts"/> object for checking contracts on the specified boolean value.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The boolean value to check.</param>
        /// <returns>A <see cref="BooleanContracts"/> instance.</returns>
        public static BooleanContracts Should(this bool subject)
        {
            return new BooleanContracts(subject);
        }

        /// <summary>
        /// Returns a <see cref="NullableBooleanContracts"/> object for checking contracts on the specified nullable boolean value.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The nullable boolean value to check.</param>
        /// <returns>A <see cref="NullableBooleanContracts"/> instance.</returns>
        public static NullableBooleanContracts Should(this bool? subject)
        {
            return new NullableBooleanContracts(subject);
        }
    }
}
