using System;
using Ave.Extensions.ErrorPaths;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Base class containing assertion methods for Func{T} delegates.
    /// </summary>
    /// <typeparam name="T">The return type of the function.</typeparam>
    /// <typeparam name="TSelf">The concrete assertion type (CRTP pattern for fluent chaining).</typeparam>
    public abstract class FunctionAssertionsBase<T, TSelf> : Assertions<Func<T>, TSelf>
        where TSelf : FunctionAssertionsBase<T, TSelf>
    {
        private Exception? _capturedException;
        private T? _capturedResult;
        private bool _hasInvoked;
        private bool _hasResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionAssertionsBase{T, TSelf}"/> class.
        /// </summary>
        /// <param name="func">The function to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure instead of recording it.</param>
        protected FunctionAssertionsBase(Func<T> func, bool throwOnFailure) : base(func, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the function throws an exception of type <typeparamref name="TException"/>.
        /// </summary>
        /// <typeparam name="TException">The expected exception type (or a derived type).</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionAssertions object to further assert on the thrown exception.</returns>
        public ExceptionAssertions<TException> Throw<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (_capturedException is null)
            {
                var error = new Error(
                    FunctionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return CreateFailedExceptionAssertions<TException>(error, because, becauseArgs);
            }

            if (_capturedException is not TException)
            {
                var error = new Error(
                    FunctionAssertionCodes.Throw,
                    $"Expected a <{typeof(TException).Name}> to be thrown, but found <{_capturedException.GetType().Name}>: {_capturedException.Message}");
                return CreateFailedExceptionAssertions<TException>(error, because, becauseArgs);
            }

            return new ExceptionAssertions<TException>((TException)_capturedException);
        }

        /// <summary>
        /// Asserts that the function throws an exception of exactly type <typeparamref name="TException"/> (and not a derived type).
        /// </summary>
        /// <typeparam name="TException">The exact expected exception type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>An ExceptionAssertions object to further assert on the thrown exception.</returns>
        public ExceptionAssertions<TException> ThrowExactly<TException>(string because = "", params object[] becauseArgs)
            where TException : Exception
        {
            EnsureInvoked();

            if (_capturedException is null)
            {
                var error = new Error(
                    FunctionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but no exception was thrown");
                return CreateFailedExceptionAssertions<TException>(error, because, becauseArgs);
            }

            if (_capturedException.GetType() != typeof(TException))
            {
                var error = new Error(
                    FunctionAssertionCodes.ThrowExactly,
                    $"Expected exactly <{typeof(TException).Name}> to be thrown, but found <{_capturedException.GetType().Name}>: {_capturedException.Message}");
                return CreateFailedExceptionAssertions<TException>(error, because, becauseArgs);
            }

            return new ExceptionAssertions<TException>((TException)_capturedException);
        }

        /// <summary>
        /// Asserts that the function does not throw any exception and returns its result.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf NotThrow(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            return Assert(
                _ => _capturedException is null,
                FunctionAssertionCodes.NotThrow,
                _capturedException is not null
                    ? $"Did not expect any exception to be thrown, but found <{_capturedException.GetType().Name}>: {_capturedException.Message}"
                    : "Did not expect any exception to be thrown",
                e => e.With("thrownException", _capturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", _capturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function does not throw an exception of type <typeparamref name="TException"/>.
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
                _ => _capturedException is not TException,
                FunctionAssertionCodes.NotThrow,
                _capturedException is TException
                    ? $"Did not expect exception of type <{typeof(TException).Name}> to be thrown, but found: {_capturedException.Message}"
                    : $"Did not expect exception of type <{typeof(TException).Name}> to be thrown",
                e => e.With("unexpectedExceptionType", typeof(TException).Name)
                      .With("thrownException", _capturedException?.GetType().Name ?? "(none)")
                      .With("exceptionMessage", _capturedException?.Message ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function returns the expected value.
        /// </summary>
        /// <param name="expected">The expected return value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf Return(T expected, string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            if (_capturedException is not null)
            {
                return Assert(
                    _ => false,
                    FunctionAssertionCodes.Return,
                    $"Expected function to return '{expected}' but it threw <{_capturedException.GetType().Name}>: {_capturedException.Message}",
                    e => e.With("expected", expected?.ToString() ?? "(null)")
                          .With("thrownException", _capturedException.GetType().Name)
                          .With("reason", FormatBecause(because, becauseArgs)));
            }

            return Assert(
                _ => _hasResult && Equals(_capturedResult, expected),
                FunctionAssertionCodes.Return,
                $"Expected function to return '{expected}' but found '{_capturedResult}'",
                e => e.With("expected", expected?.ToString() ?? "(null)")
                      .With("actual", _capturedResult?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function does not return the unexpected value.
        /// </summary>
        /// <param name="unexpected">The unexpected return value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf NotReturn(T unexpected, string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            if (_capturedException is not null)
            {
                // If an exception was thrown, it didn't return the value
                return (TSelf)this;
            }

            return Assert(
                _ => !_hasResult || !Equals(_capturedResult, unexpected),
                FunctionAssertionCodes.NotReturn,
                $"Did not expect function to return '{unexpected}'",
                e => e.With("unexpected", unexpected?.ToString() ?? "(null)")
                      .With("actual", _capturedResult?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function returns a non-null value.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf ReturnNotNull(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            if (_capturedException is not null)
            {
                return Assert(
                    _ => false,
                    FunctionAssertionCodes.ReturnNotNull,
                    $"Expected function to return a non-null value but it threw <{_capturedException.GetType().Name}>: {_capturedException.Message}",
                    e => e.With("thrownException", _capturedException.GetType().Name)
                          .With("reason", FormatBecause(because, becauseArgs)));
            }

            return Assert(
                _ => _hasResult && _capturedResult is not null,
                FunctionAssertionCodes.ReturnNotNull,
                "Expected function to return a non-null value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function returns null.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf ReturnNull(string because = "", params object[] becauseArgs)
        {
            EnsureInvoked();

            if (_capturedException is not null)
            {
                return Assert(
                    _ => false,
                    FunctionAssertionCodes.ReturnNull,
                    $"Expected function to return null but it threw <{_capturedException.GetType().Name}>: {_capturedException.Message}",
                    e => e.With("thrownException", _capturedException.GetType().Name)
                          .With("reason", FormatBecause(because, becauseArgs)));
            }

            return Assert(
                _ => _hasResult && _capturedResult is null,
                FunctionAssertionCodes.ReturnNull,
                $"Expected function to return null but found '{_capturedResult}'",
                e => e.With("actual", _capturedResult?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the function's return value satisfies the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate that the return value must satisfy.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>This assertion instance for chaining.</returns>
        public TSelf Satisfy(Func<T, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            EnsureInvoked();

            if (_capturedException is not null)
            {
                return Assert(
                    _ => false,
                    FunctionAssertionCodes.Satisfy,
                    $"Expected function to satisfy predicate but it threw <{_capturedException.GetType().Name}>: {_capturedException.Message}",
                    e => e.With("thrownException", _capturedException.GetType().Name)
                          .With("reason", FormatBecause(because, becauseArgs)));
            }

            return Assert(
                _ => _hasResult && predicate(_capturedResult!),
                FunctionAssertionCodes.Satisfy,
                $"Expected function result '{_capturedResult}' to satisfy predicate but it did not",
                e => e.With("actual", _capturedResult?.ToString() ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Gets the captured result of the function invocation.
        /// </summary>
        /// <returns>The captured result, or default if an exception was thrown.</returns>
        public T? GetResult()
        {
            EnsureInvoked();
            return _capturedResult;
        }

        private void EnsureInvoked()
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
                _capturedResult = Subject();
                _hasResult = true;
            }
            catch (Exception ex)
            {
                _capturedException = ex;
            }
        }

        private static ExceptionAssertions<TException> CreateFailedExceptionAssertions<TException>(
            Error error, string because, object[] becauseArgs)
            where TException : Exception
        {
            var reason = FormatBecause(because, becauseArgs);
            var assertions = new ExceptionAssertions<TException>(null);
            return assertions.Assert(
                _ => false,
                error.Code,
                error.Message,
                e => e.With("reason", reason));
        }
    }
}
