using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for nullable boolean values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class NullableBooleanContracts : NullableBooleanContractsBase<NullableBooleanContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullableBooleanContracts"/> class.
        /// </summary>
        /// <param name="subject">The nullable boolean value to check.</param>
        public NullableBooleanContracts(bool? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<bool?, Error>(NullableBooleanContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(NullableBooleanContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
