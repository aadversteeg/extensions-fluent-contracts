namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for nullable boolean values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustNullableBooleanContracts : NullableBooleanContractsBase<MustNullableBooleanContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustNullableBooleanContracts"/> class.
        /// </summary>
        /// <param name="subject">The nullable boolean value to check.</param>
        public MustNullableBooleanContracts(bool? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
