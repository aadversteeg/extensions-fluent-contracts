using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Extension methods providing Must() entry points for numeric types.
    /// </summary>
    public static class MustNumericContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified int value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The int value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<int> Must(this int subject)
        {
            return new MustNumericContracts<int>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable int value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable int value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<int> Must(this int? subject)
        {
            return new MustNullableNumericContracts<int>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified long value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The long value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<long> Must(this long subject)
        {
            return new MustNumericContracts<long>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable long value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable long value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<long> Must(this long? subject)
        {
            return new MustNullableNumericContracts<long>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified short value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The short value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<short> Must(this short subject)
        {
            return new MustNumericContracts<short>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable short value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable short value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<short> Must(this short? subject)
        {
            return new MustNullableNumericContracts<short>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified byte value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The byte value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<byte> Must(this byte subject)
        {
            return new MustNumericContracts<byte>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable byte value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable byte value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<byte> Must(this byte? subject)
        {
            return new MustNullableNumericContracts<byte>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified double value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The double value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<double> Must(this double subject)
        {
            return new MustNumericContracts<double>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable double value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable double value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<double> Must(this double? subject)
        {
            return new MustNullableNumericContracts<double>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified float value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The float value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<float> Must(this float subject)
        {
            return new MustNumericContracts<float>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable float value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable float value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<float> Must(this float? subject)
        {
            return new MustNullableNumericContracts<float>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNumericContracts{T}"/> object for checking contracts on the specified decimal value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The decimal value to check.</param>
        /// <returns>A <see cref="MustNumericContracts{T}"/> instance.</returns>
        public static MustNumericContracts<decimal> Must(this decimal subject)
        {
            return new MustNumericContracts<decimal>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustNullableNumericContracts{T}"/> object for checking contracts on the specified nullable decimal value.
        /// Contract failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The nullable decimal value to check.</param>
        /// <returns>A <see cref="MustNullableNumericContracts{T}"/> instance.</returns>
        public static MustNullableNumericContracts<decimal> Must(this decimal? subject)
        {
            return new MustNullableNumericContracts<decimal>(subject);
        }
    }
}
