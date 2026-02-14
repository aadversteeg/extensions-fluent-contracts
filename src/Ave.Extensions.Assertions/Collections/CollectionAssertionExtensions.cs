using System.Collections.Generic;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for collection types.
    /// </summary>
    public static class CollectionAssertionExtensions
    {
        /// <summary>
        /// Returns a <see cref="CollectionAssertions{T}"/> object for asserting on the specified collection.
        /// Failures are recorded and can be converted to Result types.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="subject">The collection to assert on.</param>
        /// <returns>A <see cref="CollectionAssertions{T}"/> instance.</returns>
        public static CollectionAssertions<T> Should<T>(this IEnumerable<T>? subject)
        {
            return new CollectionAssertions<T>(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustCollectionAssertions{T}"/> object for asserting on the specified collection.
        /// Failures throw immediately.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="subject">The collection to assert on.</param>
        /// <returns>A <see cref="MustCollectionAssertions{T}"/> instance.</returns>
        public static MustCollectionAssertions<T> Must<T>(this IEnumerable<T>? subject)
        {
            return new MustCollectionAssertions<T>(subject);
        }

        /// <summary>
        /// Returns a <see cref="StringCollectionAssertions"/> object for asserting on the specified string collection.
        /// Failures are recorded and can be converted to Result types.
        /// </summary>
        /// <param name="subject">The string collection to assert on.</param>
        /// <returns>A <see cref="StringCollectionAssertions"/> instance.</returns>
        public static StringCollectionAssertions Should(this IEnumerable<string?>? subject)
        {
            return new StringCollectionAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustStringCollectionAssertions"/> object for asserting on the specified string collection.
        /// Failures throw immediately.
        /// </summary>
        /// <param name="subject">The string collection to assert on.</param>
        /// <returns>A <see cref="MustStringCollectionAssertions"/> instance.</returns>
        public static MustStringCollectionAssertions Must(this IEnumerable<string?>? subject)
        {
            return new MustStringCollectionAssertions(subject);
        }
    }
}
