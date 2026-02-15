using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for enum types.
    /// </summary>
    public static class MustEnumContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustEnumContracts{TEnum}"/> object for checking contracts on the specified enum value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The enum value to check.</param>
        /// <returns>A <see cref="MustEnumContracts{TEnum}"/> instance.</returns>
        public static MustEnumContracts<TEnum> Must<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new MustEnumContracts<TEnum>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustEnumContracts{TEnum}"/> object for checking contracts on the specified nullable enum value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The nullable enum value to check.</param>
        /// <returns>A <see cref="MustEnumContracts{TEnum}"/> instance.</returns>
        public static MustEnumContracts<TEnum> Must<TEnum>(this TEnum? subject)
            where TEnum : struct, Enum
        {
            return new MustEnumContracts<TEnum>(subject);
        }
    }
}
