using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.FluentContracts;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Contains contract methods for Action delegates, including Throw and NotThrow contracts.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class ActionContracts : ActionContractsBase<ActionContracts>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionContracts"/> class.
        /// </summary>
        /// <param name="action">The action to check.</param>
        public ActionContracts(Action action) : base(action, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Asserts that the current action throws an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type (or a derived type).</typeparam>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionContracts object to further check on the thrown exception.</returns>
        public ExceptionContracts<TException> Throw<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionContractCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new ExceptionContracts<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException is not TException)
            {
                var error = new Error(
                    ExceptionContractCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new ExceptionContracts<TException>(null).WithError(error, because, becauseArgs);
            }

            return new ExceptionContracts<TException>((TException)CapturedException);
        }

        /// <summary>
        /// Asserts that the current action throws an exception of exactly type <typeparamref name="TException"/> (and not a derived type).
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionContracts object to further check on the thrown exception.</returns>
        public ExceptionContracts<TException> ThrowExactly<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionContractCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new ExceptionContracts<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException.GetType() != typeof(TException))
            {
                var error = new Error(
                    ExceptionContractCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new ExceptionContracts<TException>(null).WithError(error, because, becauseArgs);
            }

            return new ExceptionContracts<TException>((TException)CapturedException);
        }

        /// <summary>
        /// Implicitly converts a contract to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Action, Error>(ActionContracts contracts)
        {
            return contracts.ToResult();
        }

        /// <summary>
        /// Implicitly converts a contract to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="contracts">The contract instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ActionContracts contracts)
        {
            return contracts.ToVoidResult();
        }
    }
}
