using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for all contract types. Provides the contract infrastructure
    /// including short-circuit evaluation, error tracking, and optional throwing on failure.
    /// </summary>
    /// <typeparam name="TSubject">The type of the value being checked.</typeparam>
    /// <typeparam name="TSelf">The concrete contract type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class Contracts<TSubject, TSelf>
        where TSelf : Contracts<TSubject, TSelf>
    {
        private Error? _failure;
        private readonly bool _throwOnFailure;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contracts{TSubject, TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The value being checked.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure instead of recording it.</param>
        protected Contracts(TSubject subject, bool throwOnFailure = false)
        {
            Subject = subject;
            _throwOnFailure = throwOnFailure;
        }

        /// <summary>
        /// Gets the value being checked.
        /// </summary>
        public TSubject Subject { get; }

        /// <summary>
        /// Gets this contract instance for fluent chaining.
        /// </summary>
        public TSelf And => (TSelf)this;

        /// <summary>
        /// Gets a value indicating whether a failure has been recorded.
        /// </summary>
        public bool HasFailure => _failure.HasValue;

        /// <summary>
        /// Evaluates a contract condition and records a failure if the condition is not met.
        /// This method is public to allow third-party packages to add contract methods.
        /// Short-circuits: if a previous contract has already failed, this method does nothing.
        /// </summary>
        /// <param name="condition">The condition to evaluate. Returns true if the contract passes.</param>
        /// <param name="code">The error code to use if the contract fails.</param>
        /// <param name="message">The error message to use if the contract fails.</param>
        /// <returns>This contract instance for fluent chaining.</returns>
        public TSelf Assert(
            Func<TSubject, bool> condition,
            ErrorCode code,
            string message)
        {
            return Assert(condition, code, message, null);
        }

        /// <summary>
        /// Evaluates a contract condition and records a failure with metadata if the condition is not met.
        /// This method is public to allow third-party packages to add contract methods.
        /// Short-circuits: if a previous contract has already failed, this method does nothing.
        /// </summary>
        /// <param name="condition">The condition to evaluate. Returns true if the contract passes.</param>
        /// <param name="code">The error code to use if the contract fails.</param>
        /// <param name="message">The error message to use if the contract fails.</param>
        /// <param name="enrich">A function to enrich the error with metadata. Since Error is a readonly struct, this function returns a new Error instance.</param>
        /// <returns>This contract instance for fluent chaining.</returns>
        public TSelf Assert(
            Func<TSubject, bool> condition,
            ErrorCode code,
            string message,
            Func<Error, Error>? enrich)
        {
            if (_failure is null && !condition(Subject))
            {
                var error = new Error(code, message);
                _failure = enrich is not null ? enrich(error) : error;

                if (_throwOnFailure)
                {
                    TestFrameworkDetector.Throw(_failure.Value.ToString());
                }
            }
            return (TSelf)this;
        }

        /// <summary>
        /// Converts the contract chain to a Result. Used by Should-variant implicit conversions.
        /// </summary>
        /// <returns>A Result containing either the subject value or the error.</returns>
        protected Result<TSubject, Error> ToResult()
        {
            return _failure is null
                ? Result<TSubject, Error>.Success(Subject)
                : Result<TSubject, Error>.Failure(_failure.Value);
        }

        /// <summary>
        /// Converts the contract chain to a VoidResult. Used by Should-variant implicit conversions.
        /// </summary>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        protected VoidResult<Error> ToVoidResult()
        {
            return _failure is null
                ? VoidResult<Error>.Success()
                : VoidResult<Error>.Failure(_failure.Value);
        }

        /// <summary>
        /// Formats a 'because' reason string with optional format arguments.
        /// </summary>
        /// <param name="because">The reason string, possibly containing format placeholders.</param>
        /// <param name="becauseArgs">Optional format arguments.</param>
        /// <returns>The formatted reason string, or empty string if because is null or empty.</returns>
        protected static string FormatBecause(string because, object[] becauseArgs)
        {
            if (string.IsNullOrEmpty(because))
            {
                return string.Empty;
            }

            return becauseArgs.Length > 0
                ? string.Format(because, becauseArgs)
                : because;
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<TSubject, Error>(Contracts<TSubject, TSelf> contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(Contracts<TSubject, TSelf> contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
