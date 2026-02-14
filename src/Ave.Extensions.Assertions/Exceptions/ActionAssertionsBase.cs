using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Exceptions
{
    /// <summary>
    /// Base class for action assertions containing shared functionality.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class ActionAssertionsBase<TSelf> : Assertions<Action, TSelf>
        where TSelf : ActionAssertionsBase<TSelf>
    {
        /// <summary>
        /// The captured exception from invoking the action.
        /// </summary>
        protected Exception? CapturedException;

        private bool _hasInvoked;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="action">The action to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected ActionAssertionsBase(Action action, bool throwOnFailure) : base(action, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current action does not throw any exception.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf NotThrow(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            return Assert(
                _ => CapturedException is null,
                ExceptionAssertionCodes.NotThrow,
                CapturedException is not null
                    ? $"Did not expect any exception to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}"
                    : "Did not expect any exception to be thrown",
                e => e.With("thrownException", CapturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", CapturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current action does not throw an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The exception type that should not be thrown.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf NotThrow<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            return Assert(
                _ => CapturedException is not TException,
                ExceptionAssertionCodes.NotThrow,
                CapturedException is TException
                    ? $"Did not expect exception of type <{typeof(TException).Name}> to be thrown, but found: {CapturedException.Message}"
                    : $"Did not expect exception of type <{typeof(TException).Name}> to be thrown",
                e => e.With("unexpectedExceptionType", typeof(TException).Name)
                      .With("thrownException", CapturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", CapturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Ensures the action has been invoked and captures any exception.
        /// </summary>
        protected void EnsureInvoked()
        {
            if (_hasInvoked)
            {
                return;
            }

            _hasInvoked = true;

            if (Subject is null)
            {
                return;
            }

            try
            {
                Subject();
            }
            catch (Exception ex)
            {
                CapturedException = ex;
            }
        }
    }

    /// <summary>
    /// Internal helper extension to propagate errors through ExceptionAssertions.
    /// </summary>
    internal static class ExceptionAssertionsErrorHelper
    {
        /// <summary>
        /// Sets an initial error on the ExceptionAssertions for cases where the throw assertion itself failed.
        /// </summary>
        internal static ExceptionAssertions<TException> WithError<TException>(
            this ExceptionAssertions<TException> assertions,
            Error error,
            string because,
            object[] becauseArgs)
            where TException : Exception
        {
            var reason = FormatBecause(because, becauseArgs);

            // Use the Assert method to set the failure
            return assertions.Assert(
                _ => false,
                error.Code,
                error.Message,
                e => e.With("reason", reason));
        }

        /// <summary>
        /// Sets an initial error on the MustExceptionAssertions for cases where the throw assertion itself failed.
        /// </summary>
        internal static MustExceptionAssertions<TException> WithError<TException>(
            this MustExceptionAssertions<TException> assertions,
            Error error,
            string because,
            object[] becauseArgs)
            where TException : Exception
        {
            var reason = FormatBecause(because, becauseArgs);

            // Use the Assert method to set the failure
            return assertions.Assert(
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
