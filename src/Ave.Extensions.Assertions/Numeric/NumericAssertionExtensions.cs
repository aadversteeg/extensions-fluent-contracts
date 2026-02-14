namespace Ave.Extensions.Assertions.Numeric
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for numeric types.
    /// </summary>
    public static class NumericAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified int value.
        /// </summary>
        public static NumericAssertions<int> Should(this int subject) => new NumericAssertions<int>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified int value.
        /// </summary>
        public static MustNumericAssertions<int> Must(this int subject) => new MustNumericAssertions<int>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified uint value.
        /// </summary>
        public static NumericAssertions<uint> Should(this uint subject) => new NumericAssertions<uint>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified uint value.
        /// </summary>
        public static MustNumericAssertions<uint> Must(this uint subject) => new MustNumericAssertions<uint>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified long value.
        /// </summary>
        public static NumericAssertions<long> Should(this long subject) => new NumericAssertions<long>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified long value.
        /// </summary>
        public static MustNumericAssertions<long> Must(this long subject) => new MustNumericAssertions<long>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified ulong value.
        /// </summary>
        public static NumericAssertions<ulong> Should(this ulong subject) => new NumericAssertions<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified ulong value.
        /// </summary>
        public static MustNumericAssertions<ulong> Must(this ulong subject) => new MustNumericAssertions<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified short value.
        /// </summary>
        public static NumericAssertions<short> Should(this short subject) => new NumericAssertions<short>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified short value.
        /// </summary>
        public static MustNumericAssertions<short> Must(this short subject) => new MustNumericAssertions<short>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified ushort value.
        /// </summary>
        public static NumericAssertions<ushort> Should(this ushort subject) => new NumericAssertions<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified ushort value.
        /// </summary>
        public static MustNumericAssertions<ushort> Must(this ushort subject) => new MustNumericAssertions<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified byte value.
        /// </summary>
        public static NumericAssertions<byte> Should(this byte subject) => new NumericAssertions<byte>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified byte value.
        /// </summary>
        public static MustNumericAssertions<byte> Must(this byte subject) => new MustNumericAssertions<byte>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified sbyte value.
        /// </summary>
        public static NumericAssertions<sbyte> Should(this sbyte subject) => new NumericAssertions<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified sbyte value.
        /// </summary>
        public static MustNumericAssertions<sbyte> Must(this sbyte subject) => new MustNumericAssertions<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified float value.
        /// </summary>
        public static NumericAssertions<float> Should(this float subject) => new NumericAssertions<float>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified float value.
        /// </summary>
        public static MustNumericAssertions<float> Must(this float subject) => new MustNumericAssertions<float>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified double value.
        /// </summary>
        public static NumericAssertions<double> Should(this double subject) => new NumericAssertions<double>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified double value.
        /// </summary>
        public static MustNumericAssertions<double> Must(this double subject) => new MustNumericAssertions<double>(subject);

        /// <summary>
        /// Returns a <see cref="NumericAssertions{T}"/> object for asserting on the specified decimal value.
        /// </summary>
        public static NumericAssertions<decimal> Should(this decimal subject) => new NumericAssertions<decimal>(subject);

        /// <summary>
        /// Returns a <see cref="MustNumericAssertions{T}"/> object for asserting on the specified decimal value.
        /// </summary>
        public static MustNumericAssertions<decimal> Must(this decimal subject) => new MustNumericAssertions<decimal>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable int value.
        /// </summary>
        public static NullableNumericAssertions<int> Should(this int? subject) => new NullableNumericAssertions<int>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable int value.
        /// </summary>
        public static MustNullableNumericAssertions<int> Must(this int? subject) => new MustNullableNumericAssertions<int>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable uint value.
        /// </summary>
        public static NullableNumericAssertions<uint> Should(this uint? subject) => new NullableNumericAssertions<uint>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable uint value.
        /// </summary>
        public static MustNullableNumericAssertions<uint> Must(this uint? subject) => new MustNullableNumericAssertions<uint>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable long value.
        /// </summary>
        public static NullableNumericAssertions<long> Should(this long? subject) => new NullableNumericAssertions<long>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable long value.
        /// </summary>
        public static MustNullableNumericAssertions<long> Must(this long? subject) => new MustNullableNumericAssertions<long>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable ulong value.
        /// </summary>
        public static NullableNumericAssertions<ulong> Should(this ulong? subject) => new NullableNumericAssertions<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable ulong value.
        /// </summary>
        public static MustNullableNumericAssertions<ulong> Must(this ulong? subject) => new MustNullableNumericAssertions<ulong>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable short value.
        /// </summary>
        public static NullableNumericAssertions<short> Should(this short? subject) => new NullableNumericAssertions<short>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable short value.
        /// </summary>
        public static MustNullableNumericAssertions<short> Must(this short? subject) => new MustNullableNumericAssertions<short>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable ushort value.
        /// </summary>
        public static NullableNumericAssertions<ushort> Should(this ushort? subject) => new NullableNumericAssertions<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable ushort value.
        /// </summary>
        public static MustNullableNumericAssertions<ushort> Must(this ushort? subject) => new MustNullableNumericAssertions<ushort>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable byte value.
        /// </summary>
        public static NullableNumericAssertions<byte> Should(this byte? subject) => new NullableNumericAssertions<byte>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable byte value.
        /// </summary>
        public static MustNullableNumericAssertions<byte> Must(this byte? subject) => new MustNullableNumericAssertions<byte>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable sbyte value.
        /// </summary>
        public static NullableNumericAssertions<sbyte> Should(this sbyte? subject) => new NullableNumericAssertions<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable sbyte value.
        /// </summary>
        public static MustNullableNumericAssertions<sbyte> Must(this sbyte? subject) => new MustNullableNumericAssertions<sbyte>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable float value.
        /// </summary>
        public static NullableNumericAssertions<float> Should(this float? subject) => new NullableNumericAssertions<float>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable float value.
        /// </summary>
        public static MustNullableNumericAssertions<float> Must(this float? subject) => new MustNullableNumericAssertions<float>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable double value.
        /// </summary>
        public static NullableNumericAssertions<double> Should(this double? subject) => new NullableNumericAssertions<double>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable double value.
        /// </summary>
        public static MustNullableNumericAssertions<double> Must(this double? subject) => new MustNullableNumericAssertions<double>(subject);

        /// <summary>
        /// Returns a <see cref="NullableNumericAssertions{T}"/> object for asserting on the specified nullable decimal value.
        /// </summary>
        public static NullableNumericAssertions<decimal> Should(this decimal? subject) => new NullableNumericAssertions<decimal>(subject);

        /// <summary>
        /// Returns a <see cref="MustNullableNumericAssertions{T}"/> object for asserting on the specified nullable decimal value.
        /// </summary>
        public static MustNullableNumericAssertions<decimal> Must(this decimal? subject) => new MustNullableNumericAssertions<decimal>(subject);
    }
}
