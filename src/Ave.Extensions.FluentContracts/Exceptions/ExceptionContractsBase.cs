using System;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Base class for exception contracts containing all contract methods.
    /// </summary>
    /// <typeparam name="TException">The type of exception.</typeparam>
    /// <typeparam name="TSelf">The concrete contract type for fluent chaining.</typeparam>
    public abstract class ExceptionContractsBase<TException, TSelf> : Contracts<TException?, TSelf>
        where TException : Exception
        where TSelf : ExceptionContractsBase<TException, TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionContractsBase{TException, TSelf}"/> class.
        /// </summary>
        /// <param name="exception">The exception to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on contract failure.</param>
        protected ExceptionContractsBase(TException? exception, bool throwOnFailure)
            : base(exception, throwOnFailure)
        {
        }

        /// <summary>
        /// Gets the exception object of the exception thrown.
        /// </summary>
        public TException? Which => Subject;

        /// <summary>
        /// Asserts that the thrown exception has a message that matches the expected pattern.
        /// </summary>
        /// <param name="expectedMessage">The expected message (supports * and ? wildcards).</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf WithMessage(string expectedMessage, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && MatchesPattern(s.Message, expectedMessage),
                ExceptionContractCodes.WithMessage,
                Subject is not null
                    ? $"Expected exception with message matching '{expectedMessage}' but found '{Subject.Message}'"
                    : $"Expected exception with message matching '{expectedMessage}' but no exception was thrown",
                e => e.With("expectedPattern", expectedMessage)
                      .With("actualMessage", Subject?.Message ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the thrown exception contains an inner exception of type T.
        /// </summary>
        /// <typeparam name="TInnerException">The expected type of the inner exception.</typeparam>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        public TSelf WithInnerException<TInnerException>(string because = "", params object[] becauseArgs)
            where TInnerException : Exception
        {
            return Assert(
                s => s?.InnerException is TInnerException,
                ExceptionContractCodes.WithInnerException,
                Subject is not null
                    ? Subject.InnerException is not null
                        ? $"Expected exception with inner exception of type '{typeof(TInnerException).Name}' but found '{Subject.InnerException.GetType().Name}'"
                        : $"Expected exception with inner exception of type '{typeof(TInnerException).Name}' but there was no inner exception"
                    : $"Expected exception with inner exception of type '{typeof(TInnerException).Name}' but no exception was thrown",
                e => e.With("expectedInnerType", typeof(TInnerException).Name)
                      .With("actualInnerType", Subject?.InnerException?.GetType().Name ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the thrown exception contains an inner exception of the specified type.
        /// </summary>
        /// <param name="innerExceptionType">The expected type of the inner exception.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when innerExceptionType is null.</exception>
        public TSelf WithInnerException(Type innerExceptionType, string because = "", params object[] becauseArgs)
        {
            if (innerExceptionType is null)
            {
                throw new ArgumentNullException(nameof(innerExceptionType));
            }

            return Assert(
                s => s?.InnerException is not null && innerExceptionType.IsInstanceOfType(s.InnerException),
                ExceptionContractCodes.WithInnerException,
                Subject is not null
                    ? Subject.InnerException is not null
                        ? $"Expected exception with inner exception of type '{innerExceptionType.Name}' but found '{Subject.InnerException.GetType().Name}'"
                        : $"Expected exception with inner exception of type '{innerExceptionType.Name}' but there was no inner exception"
                    : $"Expected exception with inner exception of type '{innerExceptionType.Name}' but no exception was thrown",
                e => e.With("expectedInnerType", innerExceptionType.Name)
                      .With("actualInnerType", Subject?.InnerException?.GetType().Name ?? "(none)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the exception matches a particular condition.
        /// </summary>
        /// <param name="predicate">The condition that the exception must match.</param>
        /// <param name="because">A reason why this contract is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The contract instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf Where(Func<TException, bool> predicate, string because = "", params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Assert(
                s => s is not null && predicate(s),
                ExceptionContractCodes.Where,
                "Expected exception to match the predicate but the condition was not met",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Matches a string against a wildcard pattern (* and ? supported).
        /// </summary>
        /// <param name="input">The string to match.</param>
        /// <param name="pattern">The pattern with wildcards.</param>
        /// <returns>True if the input matches the pattern.</returns>
        protected static bool MatchesPattern(string input, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return string.IsNullOrEmpty(input);
            }

            // Simple wildcard matching: * matches any characters, ? matches single character
            int inputIndex = 0;
            int patternIndex = 0;
            int starInputIndex = -1;
            int starPatternIndex = -1;

            while (inputIndex < input.Length)
            {
                if (patternIndex < pattern.Length && (pattern[patternIndex] == '?' || pattern[patternIndex] == input[inputIndex]))
                {
                    inputIndex++;
                    patternIndex++;
                }
                else if (patternIndex < pattern.Length && pattern[patternIndex] == '*')
                {
                    starPatternIndex = patternIndex;
                    starInputIndex = inputIndex;
                    patternIndex++;
                }
                else if (starPatternIndex >= 0)
                {
                    patternIndex = starPatternIndex + 1;
                    starInputIndex++;
                    inputIndex = starInputIndex;
                }
                else
                {
                    return false;
                }
            }

            while (patternIndex < pattern.Length && pattern[patternIndex] == '*')
            {
                patternIndex++;
            }

            return patternIndex == pattern.Length;
        }
    }
}
