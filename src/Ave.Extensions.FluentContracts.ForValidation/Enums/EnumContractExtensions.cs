using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods for enum contracts.
    /// </summary>
    public static class EnumContractExtensions
    {
        /// <summary>
        /// Returns an <see cref="EnumContracts{TEnum}"/> object for checking contracts on the specified enum.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The enum to check.</param>
        /// <returns>An <see cref="EnumContracts{TEnum}"/> instance.</returns>
        public static EnumContracts<TEnum> Should<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new EnumContracts<TEnum>(subject);
        }

        /// <summary>
        /// Returns an <see cref="EnumContracts{TEnum}"/> object for checking contracts on the specified nullable enum.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The nullable enum to check.</param>
        /// <returns>An <see cref="EnumContracts{TEnum}"/> instance.</returns>
        public static EnumContracts<TEnum> Should<TEnum>(this TEnum? subject)
            where TEnum : struct, Enum
        {
            return new EnumContracts<TEnum>(subject);
        }
    }
}
