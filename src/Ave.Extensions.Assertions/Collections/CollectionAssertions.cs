using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Collections
{
    /// <summary>
    /// Contains assertion methods for collections. Returns Result types on implicit conversion.
    /// Use Should() extension method to create instances.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public sealed class CollectionAssertions<T> : CollectionAssertionsBase<T, CollectionAssertions<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertions{T}"/> class.
        /// </summary>
        /// <param name="subject">The collection to assert on.</param>
        public CollectionAssertions(IEnumerable<T>? subject) : base(subject, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<IEnumerable<T>?, Error>(CollectionAssertions<T> assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(CollectionAssertions<T> assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
