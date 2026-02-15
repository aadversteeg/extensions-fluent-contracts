using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for Enum values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    public sealed class EnumContracts<TEnum> : EnumContractsBase<TEnum, EnumContracts<TEnum>>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumContracts{TEnum}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to check.</param>
        public EnumContracts(TEnum? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<TEnum?, Error>(EnumContracts<TEnum> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(EnumContracts<TEnum> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
