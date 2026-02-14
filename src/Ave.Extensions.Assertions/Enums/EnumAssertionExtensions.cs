using System;

namespace Ave.Extensions.Assertions.Enums
{
    /// <summary>
    /// Extension methods for enum assertions.
    /// </summary>
    public static class EnumAssertionExtensions
    {
        /// <summary>
        /// Returns an <see cref="EnumAssertions{TEnum}"/> object for asserting on the specified enum.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The enum to assert on.</param>
        /// <returns>An <see cref="EnumAssertions{TEnum}"/> instance.</returns>
        public static EnumAssertions<TEnum> Should<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new EnumAssertions<TEnum>(subject);
        }

        /// <summary>
        /// Returns an <see cref="EnumAssertions{TEnum}"/> object for asserting on the specified nullable enum.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The nullable enum to assert on.</param>
        /// <returns>An <see cref="EnumAssertions{TEnum}"/> instance.</returns>
        public static EnumAssertions<TEnum> Should<TEnum>(this TEnum? subject)
            where TEnum : struct, Enum
        {
            return new EnumAssertions<TEnum>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustEnumAssertions{TEnum}"/> object for asserting on the specified enum.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The enum to assert on.</param>
        /// <returns>A <see cref="MustEnumAssertions{TEnum}"/> instance.</returns>
        public static MustEnumAssertions<TEnum> Must<TEnum>(this TEnum subject)
            where TEnum : struct, Enum
        {
            return new MustEnumAssertions<TEnum>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustEnumAssertions{TEnum}"/> object for asserting on the specified nullable enum.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <typeparam name="TEnum">The enum type.</typeparam>
        /// <param name="subject">The nullable enum to assert on.</param>
        /// <returns>A <see cref="MustEnumAssertions{TEnum}"/> instance.</returns>
        public static MustEnumAssertions<TEnum> Must<TEnum>(this TEnum? subject)
            where TEnum : struct, Enum
        {
            return new MustEnumAssertions<TEnum>(subject);
        }
    }
}
