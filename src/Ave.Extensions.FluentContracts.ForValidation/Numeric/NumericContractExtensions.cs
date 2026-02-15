namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for numeric types.
    /// </summary>
    public static class NumericContractExtensions
    {
        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified int value.
        /// </summary>
        public static NumericContracts<int> Should(this int subject) => new NumericContracts<int>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified uint value.
        /// </summary>
        public static NumericContracts<uint> Should(this uint subject) => new NumericContracts<uint>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified long value.
        /// </summary>
        public static NumericContracts<long> Should(this long subject) => new NumericContracts<long>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified ulong value.
        /// </summary>
        public static NumericContracts<ulong> Should(this ulong subject) => new NumericContracts<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified short value.
        /// </summary>
        public static NumericContracts<short> Should(this short subject) => new NumericContracts<short>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified ushort value.
        /// </summary>
        public static NumericContracts<ushort> Should(this ushort subject) => new NumericContracts<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified byte value.
        /// </summary>
        public static NumericContracts<byte> Should(this byte subject) => new NumericContracts<byte>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified sbyte value.
        /// </summary>
        public static NumericContracts<sbyte> Should(this sbyte subject) => new NumericContracts<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified float value.
        /// </summary>
        public static NumericContracts<float> Should(this float subject) => new NumericContracts<float>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified double value.
        /// </summary>
        public static NumericContracts<double> Should(this double subject) => new NumericContracts<double>(subject);

        /// <summary>
        /// Returns a <see cref="NumericContracts{T}"/> object for checking contracts on the specified decimal value.
        /// </summary>
        public static NumericContracts<decimal> Should(this decimal subject) => new NumericContracts<decimal>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable int value.
        /// </summary>
        public static NullableNumericContracts<int> Should(this int? subject) => new NullableNumericContracts<int>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable uint value.
        /// </summary>
        public static NullableNumericContracts<uint> Should(this uint? subject) => new NullableNumericContracts<uint>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable long value.
        /// </summary>
        public static NullableNumericContracts<long> Should(this long? subject) => new NullableNumericContracts<long>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable ulong value.
        /// </summary>
        public static NullableNumericContracts<ulong> Should(this ulong? subject) => new NullableNumericContracts<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable short value.
        /// </summary>
        public static NullableNumericContracts<short> Should(this short? subject) => new NullableNumericContracts<short>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable ushort value.
        /// </summary>
        public static NullableNumericContracts<ushort> Should(this ushort? subject) => new NullableNumericContracts<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable byte value.
        /// </summary>
        public static NullableNumericContracts<byte> Should(this byte? subject) => new NullableNumericContracts<byte>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable sbyte value.
        /// </summary>
        public static NullableNumericContracts<sbyte> Should(this sbyte? subject) => new NullableNumericContracts<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable float value.
        /// </summary>
        public static NullableNumericContracts<float> Should(this float? subject) => new NullableNumericContracts<float>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable double value.
        /// </summary>
        public static NullableNumericContracts<double> Should(this double? subject) => new NullableNumericContracts<double>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericContracts{T}"/> object for checking contracts on the specified nullable decimal value.
        /// </summary>
        public static NullableNumericContracts<decimal> Should(this decimal? subject) => new NullableNumericContracts<decimal>(subject);
    }
}
