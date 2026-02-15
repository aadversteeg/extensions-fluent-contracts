using System;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for action contracts containing shared functionality.
    /// </summary>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class ActionContractsBase<TSelf> : Contracts<Action, TSelf>
        where TSelf : ActionContractsBase<TSelf>
    {
        /// <summary>
        /// The captured exception from invoking the action.
        /// </summary>
        protected Exception? CapturedException;

        private bool _hasInvoked;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionContractsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="action">The action to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected ActionContractsBase(Action action, bool throwOnFailure) : base(action, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current action does not throw any exception.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This contract instance for chaining.</returns>
        public TSelf NotThrow(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            return Assert(
                _ => CapturedException is null,
                ExceptionContractCodes.NotThrow,
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
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This contract instance for chaining.</returns>
        public TSelf NotThrow<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            return Assert(
                _ => CapturedException is not TException,
                ExceptionContractCodes.NotThrow,
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
}
