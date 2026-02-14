using System;

namespace Ave.Extensions.Assertions.Objects
{
    /// <summary>
    /// Base class for object assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class ObjectAssertionsBase<TSelf> : Assertions<object?, TSelf>
        where TSelf : ObjectAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The object value to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected ObjectAssertionsBase(object? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current object has not been initialized (is null).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeNull(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is null,
                ObjectAssertionCodes.BeNull,
                $"Expected null but found '{Subject}'",
                e => e.With("actual", Subject ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current object has been initialized (is not null).
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeNull(
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => s is not null,
                ObjectAssertionCodes.NotBeNull,
                "Expected a value but found null",
                e => e.With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object equals the expected value using Object.Equals.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(
            object? expected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => Equals(s, expected),
                ObjectAssertionCodes.Be,
                $"Expected '{expected}' but found '{Subject}'",
                e => e.With("expected", expected ?? (object)"(null)")
                      .With("actual", Subject ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object does not equal the unexpected value using Object.Equals.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(
            object? unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => !Equals(s, unexpected),
                ObjectAssertionCodes.NotBe,
                $"Did not expect '{unexpected}'",
                e => e.With("unexpected", unexpected ?? (object)"(null)")
                      .With("actual", Subject ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object reference refers to the exact same object as another reference.
        /// </summary>
        /// <param name="expected">The expected object reference.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeSameAs(
            object? expected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => ReferenceEquals(s, expected),
                ObjectAssertionCodes.BeSameAs,
                $"Expected same reference as '{expected}' but found '{Subject}'",
                e => e.With("expected", expected ?? (object)"(null)")
                      .With("actual", Subject ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object reference does not refer to the same object as another reference.
        /// </summary>
        /// <param name="unexpected">The object reference that should not be the same.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeSameAs(
            object? unexpected,
            string because = "",
            params object[] becauseArgs)
        {
            return Assert(
                s => !ReferenceEquals(s, unexpected),
                ObjectAssertionCodes.NotBeSameAs,
                $"Did not expect same reference as '{unexpected}'",
                e => e.With("unexpected", unexpected ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object is of the specified type.
        /// </summary>
        /// <typeparam name="T">The expected type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeOfType<T>(
            string because = "",
            params object[] becauseArgs)
        {
            return BeOfType(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is of the specified type.
        /// </summary>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when expectedType is null.</exception>
        public TSelf BeOfType(
            Type expectedType,
            string because = "",
            params object[] becauseArgs)
        {
            if (expectedType is null)
            {
                throw new ArgumentNullException(nameof(expectedType));
            }

            return Assert(
                s => s is not null && s.GetType() == expectedType,
                ObjectAssertionCodes.BeOfType,
                Subject is null
                    ? $"Expected type '{expectedType.FullName}' but found null"
                    : $"Expected type '{expectedType.FullName}' but found '{Subject?.GetType().FullName}'",
                e => e.With("expectedType", expectedType.FullName ?? expectedType.Name)
                      .With("actualType", Subject?.GetType().FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object is not of the specified type.
        /// </summary>
        /// <typeparam name="T">The type the object should not be.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeOfType<T>(
            string because = "",
            params object[] becauseArgs)
        {
            return NotBeOfType(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is not of the specified type.
        /// </summary>
        /// <param name="unexpectedType">The type the object should not be.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when unexpectedType is null.</exception>
        public TSelf NotBeOfType(
            Type unexpectedType,
            string because = "",
            params object[] becauseArgs)
        {
            if (unexpectedType is null)
            {
                throw new ArgumentNullException(nameof(unexpectedType));
            }

            return Assert(
                s => s is null || s.GetType() != unexpectedType,
                ObjectAssertionCodes.NotBeOfType,
                $"Did not expect type '{unexpectedType.FullName}'",
                e => e.With("unexpectedType", unexpectedType.FullName ?? unexpectedType.Name)
                      .With("actualType", Subject?.GetType().FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object is assignable to a variable of the specified type.
        /// </summary>
        /// <typeparam name="T">The type the object should be assignable to.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeAssignableTo<T>(
            string because = "",
            params object[] becauseArgs)
        {
            return BeAssignableTo(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is assignable to a variable of the specified type.
        /// </summary>
        /// <param name="type">The type the object should be assignable to.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        public TSelf BeAssignableTo(
            Type type,
            string because = "",
            params object[] becauseArgs)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Assert(
                s => s is not null && type.IsAssignableFrom(s.GetType()),
                ObjectAssertionCodes.BeAssignableTo,
                Subject is null
                    ? $"Expected assignable to '{type.FullName}' but found null"
                    : $"Expected assignable to '{type.FullName}' but '{Subject?.GetType().FullName}' is not",
                e => e.With("expectedType", type.FullName ?? type.Name)
                      .With("actualType", Subject?.GetType().FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the object is not assignable to a variable of the specified type.
        /// </summary>
        /// <typeparam name="T">The type the object should not be assignable to.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeAssignableTo<T>(
            string because = "",
            params object[] becauseArgs)
        {
            return NotBeAssignableTo(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the object is not assignable to a variable of the specified type.
        /// </summary>
        /// <param name="type">The type the object should not be assignable to.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        public TSelf NotBeAssignableTo(
            Type type,
            string because = "",
            params object[] becauseArgs)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Assert(
                s => s is null || !type.IsAssignableFrom(s.GetType()),
                ObjectAssertionCodes.NotBeAssignableTo,
                $"Did not expect assignable to '{type.FullName}' but '{Subject?.GetType().FullName}' is",
                e => e.With("unexpectedType", type.FullName ?? type.Name)
                      .With("actualType", Subject?.GetType().FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the predicate is satisfied.
        /// </summary>
        /// <param name="predicate">The predicate which must be satisfied.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public TSelf Match(
            Func<object?, bool> predicate,
            string because = "",
            params object[] becauseArgs)
        {
            if (predicate is null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            return Assert(
                predicate,
                ObjectAssertionCodes.Match,
                $"Expected object to match predicate but found '{Subject}'",
                e => e.With("actual", Subject ?? (object)"(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
