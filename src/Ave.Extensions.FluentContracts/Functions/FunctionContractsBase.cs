using System;
using System.Threading.Tasks;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for async function contracts containing shared functionality.
    /// </summary>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class FunctionContractsBase<TSelf> : Contracts<Func<Task>, TSelf>
        where TSelf : FunctionContractsBase<TSelf>
    {
        /// <summary>
        /// The captured exception from invoking the function.
        /// </summary>
        protected Exception? CapturedException;

        private bool _hasInvoked;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionContractsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="function">The async function to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected FunctionContractsBase(Func<Task> function, bool throwOnFailure) : base(function, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current async function does not throw any exception.
        /// </summary>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This contract instance for chaining.</returns>
        public TSelf NotThrow(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            return Assert(
                _ => CapturedException is null,
                FunctionContractCodes.NotThrow,
                CapturedException is not null
                    ? $"Did not expect any exception to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}"
                    : "Did not expect any exception to be thrown",
                e => e.With("thrownException", CapturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", CapturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current async function does not throw an exception of type <typeparamref name="TException"/>.
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
                FunctionContractCodes.NotThrow,
                CapturedException is TException
                    ? $"Did not expect exception of type <{typeof(TException).Name}> to be thrown, but found: {CapturedException.Message}"
                    : $"Did not expect exception of type <{typeof(TException).Name}> to be thrown",
                e => e.With("unexpectedExceptionType", typeof(TException).Name)
                      .With("thrownException", CapturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", CapturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Ensures the async function has been invoked and captures any exception.
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
                Subject().GetAwaiter().GetResult();
            }
            catch (AggregateException ae) when (ae.InnerException is not null)
            {
                CapturedException = ae.InnerException;
            }
            catch (Exception ex)
            {
                CapturedException = ex;
            }
        }
    }
}
