using System;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions.Exceptions
{
    /// <summary>
    /// Contains assertion methods for Action delegates, including Throw and NotThrow assertions.
    /// Throws framework-specific exceptions on failure.
    /// </summary>
    public sealed class MustActionAssertions : ActionAssertionsBase<MustActionAssertions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MustActionAssertions"/> class.
        /// </summary>
        /// <param name="action">The action to assert on.</param>
        public MustActionAssertions(Action action) : base(action, throwOnFailure: true)
        {
        }

        /// <summary>
        /// Asserts that the current action throws an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type (or a derived type).</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>A MustExceptionAssertions object to further assert on the thrown exception.</returns>
        public MustExceptionAssertions<TException> Throw<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new MustExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException is not TException)
            {
                var error = new Error(
                    ExceptionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new MustExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            return new MustExceptionAssertions<TException>((TException)CapturedException);
        }

        /// <summary>
        /// Asserts that the current action throws an exception of exactly type <typeparamref name="TException"/> (and not a derived type).
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>A MustExceptionAssertions object to further assert on the thrown exception.</returns>
        public MustExceptionAssertions<TException> ThrowExactly<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (CapturedException is null)
            {
                var error = new Error(
                    ExceptionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return new MustExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            if (CapturedException.GetType() != typeof(TException))
            {
                var error = new Error(
                    ExceptionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but found <{CapturedException.GetType().Name}>: {CapturedException.Message}");
                return new MustExceptionAssertions<TException>(null).WithError(error, because, becauseArgs);
            }

            return new MustExceptionAssertions<TException>((TException)CapturedException);
        }
    }
}
