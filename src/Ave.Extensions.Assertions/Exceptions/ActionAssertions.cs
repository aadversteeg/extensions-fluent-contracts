using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Contains assertion methods for Action delegates, including Throw and NotThrow assertions.
    /// Returns Result on failure instead of throwing.
    /// </summary>
    public sealed class ActionAssertions : ActionAssertionsBase<ActionAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionAssertions"/> class.
        /// </summary>
        /// <param name="action">The action to assert on.</param>
        public ActionAssertions(Action action) : base(action, throwOnFailure: false)
        {
        }

        /// <summary>
        /// Asserts that the current action throws an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type (or a derived type).</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionAssertions object to further assert on the thrown exception.</returns>
        public ExceptionAssertions<TException> Throw<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new ExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException is not TException)
            {
                var error = new Error(
                    ExceptionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new ExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            return new ExceptionAssertions<TException>((TException)CapturedException);
        }

        /// <summary>
        /// Asserts that the current action throws an exception of exactly type <typeparamref name="TException"/> (and not a derived type).
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionAssertions object to further assert on the thrown exception.</returns>
        public ExceptionAssertions<TException> ThrowExactly<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new ExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException.GetType() != typeof(TException))
            {
                var error = new Error(
                    ExceptionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new ExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            return new ExceptionAssertions<TException>((TException)CapturedException);
        }

        /// <summary>
        /// Implicitly converts an assertion to a Result containing the subject value on success or the error on failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A Result containing either the subject value or the error.</returns>
        public static implicit operator Result<Action, Error>(ActionAssertions assertions)
        {
            return assertions.ToResult();
        }

        /// <summary>
        /// Implicitly converts an assertion to a VoidResult indicating success or failure.
        /// </summary>
        /// <param name="assertions">The assertion instance to convert.</param>
        /// <returns>A VoidResult indicating success or containing the error.</returns>
        public static implicit operator VoidResult<Error>(ActionAssertions assertions)
        {
            return assertions.ToVoidResult();
        }
    }
}
