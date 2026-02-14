using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for string collections. Returns Result types on implicit conversion.
    /// Use Should() extension method to create instances.
    /// </summary>
    public sealed class StringCollectionAssertions : StringCollectionAssertionsBase<StringCollectionAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringCollectionAssertions"/> class.
        /// </summary>
        /// <param name="subject">The string collection to assert on.</param>
        public StringCollectionAssertions(IEnumerable<string?>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IEnumerable<string?>?, Error>(StringCollectionAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(StringCollectionAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
