using System;

namespace Ave.Extensions.FluentContracts.ForTesting
{
    /// <summary>
    /// Contains contract methods for Action delegates, including Throw and NotThrow contracts.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustActionContracts : ActionContractsBase<MustActionContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustActionContracts"/> class.
        /// </summary>
        /// <param name="action">The action to check.</param>
        public MustActionContracts(Action action) : base(action, throwOnFailure: true)
        {
        }

        /// <summary>
        /// Asserts that the current action throws an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type (or a derived type).</typeparam>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>A MustExceptionContracts object to further assert on the thrown exception.</returns>
        public MustExceptionContracts<TException> Throw<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            var result = new MustExceptionContracts<TException>(CapturedException as TException);

            if (CapturedException is null)
            {
                result.Assert(
                    _ => false,
                    ExceptionContractCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but no exception was thrown",
                    e => e.With("reason", FormatBecause(because, becauseArgs)));
            }
            else if (CapturedException is not TException)
            {
                result.Assert(
                    _ => false,
                    ExceptionContractCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}",
                    e => e.With("reason", FormatBecause(because, becauseArgs)));
            }

            return result;
        }

        /// <summary>
        /// Asserts that the current action throws an exception of exactly type <typeparamref name="TException"/> (and not a derived type).
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>A MustExceptionContracts object to further assert on the thrown exception.</returns>
        public MustExceptionContracts<TException> ThrowExactly<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            var result = new MustExceptionContracts<TException>(CapturedException as TException);

            if (CapturedException is null)
            {
                result.Assert(
                    _ => false,
                    ExceptionContractCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but no exception was thrown",
                    e => e.With("reason", FormatBecause(because, becauseArgs)));
            }
            else if (CapturedException.GetType() != typeof(TException))
            {
                result.Assert(
                    _ => false,
                    ExceptionContractCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}",
                    e => e.With("reason", FormatBecause(because, becauseArgs)));
            }

            return result;
        }
    }
}
