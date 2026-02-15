using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for Enum values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    public sealed class MustEnumContracts<TEnum> : EnumContractsBase<TEnum, MustEnumContracts<TEnum>>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustEnumContracts{TEnum}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to check.</param>
        public MustEnumContracts(TEnum? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
