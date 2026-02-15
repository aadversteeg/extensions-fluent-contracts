using System;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Thrown by <c>Must()</c> when no test framework is detected.
    /// Acts as a fallback for non-test contexts.
    /// </summary>
    public sealed class ContractViolationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ContractViolationException"/>.
        /// </summary>
        /// <param name="message">The contract failure message.</param>
        public ContractViolationException(string message) : base(message)
        {
        }
    }
}
