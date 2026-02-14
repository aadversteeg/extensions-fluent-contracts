using System.Collections.Generic;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for string collections that throw on failure.
    /// Use Must() extension method to create instances.
    /// </summary>
    public sealed class MustStringCollectionAssertions : StringCollectionAssertionsBase<MustStringCollectionAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustStringCollectionAssertions"/> class.
        /// </summary>
        /// <param name="subject">The string collection to assert on.</param>
        public MustStringCollectionAssertions(IEnumerable<string?>? subject) : base(subject, throwOnFailure: true)
        {
        }
    }
}
