using System;

namespace Ave.Extensions.Assertions.Core
{
    /// <summary>
    /// Thrown by <c>Must()</c> when no test framework is detected.
    /// Acts as a fallback for non-test contexts.
    /// </summary>
    public sealed class AssertionFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="AssertionFailedException"/>.
        /// </summary>
        /// <param name="message">The assertion failure message.</param>
        public AssertionFailedException(string message) : base(message)
        {
        }
    }
}
