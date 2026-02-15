namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for object values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustObjectContracts : ObjectContractsBase<MustObjectContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustObjectContracts"/> class.
        /// </summary>
        /// <param name="subject">The object value to check.</param>
        public MustObjectContracts(object? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
