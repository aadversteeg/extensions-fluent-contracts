namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for boolean values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustBooleanContracts : BooleanContractsBase<MustBooleanContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustBooleanContracts"/> class.
        /// </summary>
        /// <param name="subject">The boolean value to check.</param>
        public MustBooleanContracts(bool subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
