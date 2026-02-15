using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.FluentContracts;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods for ExceptionContracts.
    /// </summary>
    public static class ExceptionContractsExtensions
    {
        /// <summary>
        /// Sets an initial error on the ExceptionContracts for cases where the throw contract itself failed.
        /// This is used internally when a Throw() or ThrowExactly() contract fails because no exception was thrown
        /// or the wrong exception type was thrown.
        /// </summary>
        public static ExceptionContracts<TException> WithError<TException>(
            this ExceptionContracts<TException> contracts,
            Error error,
            string because,
            object[] becauseArgs)
            where TException : Exception
        {
            var reason = FormatBecause(because, becauseArgs);

            // Use the Assert method to set the failure
            return contracts.Assert(
                _ => false,
                error.Code,
                error.Message,
                e => e.With("reason", reason));
        }

        /// <summary>
        /// Formats a 'because' reason string with optional format arguments.
        /// </summary>
        private static string FormatBecause(string because, object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(because))
            {
                return string.Empty;
            }

            return becauseArgs.Length > 0
                ? string.Format(because, becauseArgs)
                : because;
        }
    }
}
