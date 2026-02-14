using System;

namespace Ave.Extensions.Assertions.Enums
{
    /// <summary>
    /// Contains assertion methods for Enum values.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    /// <typeparam name="TEnum">The enum type.</typeparam>
    public sealed class MustEnumAssertions<TEnum> : EnumAssertionsBase<TEnum, MustEnumAssertions<TEnum>>
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustEnumAssertions{TEnum}"/> class.
        /// </summary>
        /// <param name="subject">The enum value to assert on.</param>
        public MustEnumAssertions(TEnum? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
