namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for string values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustStringContracts : StringContractsBase<MustStringContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustStringContracts"/> class.
        /// </summary>
        /// <param name="subject">The string value to check.</param>
        public MustStringContracts(string? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
