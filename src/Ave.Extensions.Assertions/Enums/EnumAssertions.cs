using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Enums
{
    /// <summary>
    /// Contains assertion methods for Enum values.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    public sealed class EnumAssertions<TEnum> : EnumAssertionsBase<TEnum, EnumAssertions<TEnum>>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumAssertions{TEnum}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to assert on.</param>
        public EnumAssertions(TEnum? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<TEnum?, Error>(EnumAssertions<TEnum> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(EnumAssertions<TEnum> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
