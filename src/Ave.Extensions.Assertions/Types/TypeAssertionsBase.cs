using System;
using System.Linq;

namespace Ave.Extensions.Assertions.Types
{
    /// <summary>
    /// Base class for Type assertions containing all assertion methods.
    /// </summary>
    /// <typeparam name="TSelf">The concrete assertion type for fluent chaining.</typeparam>
    public abstract class TypeAssertionsBase<TSelf> : Assertions<Type?, TSelf>
        where TSelf : TypeAssertionsBase<TSelf>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAssertionsBase{TSelf}"/> class.
        /// </summary>
        /// <param name="subject">The Type to assert on.</param>
        /// <param name="throwOnFailure">If true, throws an exception on assertion failure.</param>
        protected TypeAssertionsBase(Type? subject, bool throwOnFailure)
            : base(subject, throwOnFailure)
        {
        }

        /// <summary>
        /// Asserts that the current Type is equal to the specified type.
        /// </summary>
        /// <typeparam name="TExpected">The expected type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be<TExpected>(string because = "", params object[] becauseArgs)
        {
            return Be(typeof(TExpected), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type is equal to the specified type.
        /// </summary>
        /// <param name="expected">The expected type.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Be(Type expected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s == expected,
                TypeAssertionCodes.Be,
                $"Expected type to be '{expected?.FullName ?? "(null)"}' but found '{Subject?.FullName ?? "(null)"}'",
                e => e.With("expected", expected?.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not equal to the specified type.
        /// </summary>
        /// <typeparam name="TUnexpected">The unexpected type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe<TUnexpected>(string because = "", params object[] becauseArgs)
        {
            return NotBe(typeof(TUnexpected), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type is not equal to the specified type.
        /// </summary>
        /// <param name="unexpected">The unexpected type.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBe(Type unexpected, string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s != unexpected,
                TypeAssertionCodes.NotBe,
                $"Expected type not to be '{unexpected?.FullName ?? "(null)"}' but it is",
                e => e.With("unexpected", unexpected?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that an instance of the subject type is assignable to a variable of type T.
        /// </summary>
        /// <typeparam name="T">The type to which instances of the type should be assignable.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeAssignableTo<T>(string because = "", params object[] becauseArgs)
        {
            return BeAssignableTo(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that an instance of the subject type is assignable to a variable of the given type.
        /// </summary>
        /// <param name="type">The type to which instances of the type should be assignable.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        public TSelf BeAssignableTo(Type type, string because = "", params object[] becauseArgs)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Assert(
                s => s is not null && type.IsAssignableFrom(s),
                TypeAssertionCodes.BeAssignableTo,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be assignable to '{type.FullName}' but it is not"
                    : $"Expected type to be assignable to '{type.FullName}' but found null",
                e => e.With("targetType", type.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that an instance of the subject type is not assignable to a variable of type T.
        /// </summary>
        /// <typeparam name="T">The type to which instances of the type should not be assignable.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeAssignableTo<T>(string because = "", params object[] becauseArgs)
        {
            return NotBeAssignableTo(typeof(T), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that an instance of the subject type is not assignable to a variable of the given type.
        /// </summary>
        /// <param name="type">The type to which instances of the type should not be assignable.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        public TSelf NotBeAssignableTo(Type type, string because = "", params object[] becauseArgs)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Assert(
                s => s is null || !type.IsAssignableFrom(s),
                TypeAssertionCodes.NotBeAssignableTo,
                $"Expected type '{Subject?.FullName ?? "(null)"}' to not be assignable to '{type.FullName}' but it is",
                e => e.With("targetType", type.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type implements interface T.
        /// </summary>
        /// <typeparam name="TInterface">The interface that should be implemented.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf Implement<TInterface>(string because = "", params object[] becauseArgs)
            where TInterface : class
        {
            return Implement(typeof(TInterface), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type implements the specified interface.
        /// </summary>
        /// <param name="interfaceType">The interface that should be implemented.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when interfaceType is null.</exception>
        /// <exception cref="ArgumentException">Thrown when interfaceType is not an interface.</exception>
        public TSelf Implement(Type interfaceType, string because = "", params object[] becauseArgs)
        {
            if (interfaceType is null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException($"'{interfaceType.FullName}' is not an interface.", nameof(interfaceType));
            }

            return Assert(
                s => s is not null && interfaceType.IsAssignableFrom(s) && interfaceType != s,
                TypeAssertionCodes.Implement,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to implement interface '{interfaceType.FullName}' but it does not"
                    : $"Expected type to implement interface '{interfaceType.FullName}' but found null",
                e => e.With("interface", interfaceType.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type does not implement interface T.
        /// </summary>
        /// <typeparam name="TInterface">The interface that should not be implemented.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotImplement<TInterface>(string because = "", params object[] becauseArgs)
            where TInterface : class
        {
            return NotImplement(typeof(TInterface), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type does not implement the specified interface.
        /// </summary>
        /// <param name="interfaceType">The interface that should not be implemented.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when interfaceType is null.</exception>
        /// <exception cref="ArgumentException">Thrown when interfaceType is not an interface.</exception>
        public TSelf NotImplement(Type interfaceType, string because = "", params object[] becauseArgs)
        {
            if (interfaceType is null)
            {
                throw new ArgumentNullException(nameof(interfaceType));
            }

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException($"'{interfaceType.FullName}' is not an interface.", nameof(interfaceType));
            }

            return Assert(
                s => s is null || !interfaceType.IsAssignableFrom(s) || interfaceType == s,
                TypeAssertionCodes.NotImplement,
                $"Expected type '{Subject?.FullName ?? "(null)"}' to not implement interface '{interfaceType.FullName}' but it does",
                e => e.With("interface", interfaceType.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is derived from T.
        /// </summary>
        /// <typeparam name="TBaseClass">The type that should be derived from.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeDerivedFrom<TBaseClass>(string because = "", params object[] becauseArgs)
            where TBaseClass : class
        {
            return BeDerivedFrom(typeof(TBaseClass), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type is derived from the specified base type.
        /// </summary>
        /// <param name="baseType">The type that should be derived from.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when baseType is null.</exception>
        /// <exception cref="ArgumentException">Thrown when baseType is an interface.</exception>
        public TSelf BeDerivedFrom(Type baseType, string because = "", params object[] becauseArgs)
        {
            if (baseType is null)
            {
                throw new ArgumentNullException(nameof(baseType));
            }

            if (baseType.IsInterface)
            {
                throw new ArgumentException($"'{baseType.FullName}' is an interface. Use Implement() instead.", nameof(baseType));
            }

            return Assert(
                s => s is not null && s.IsSubclassOf(baseType),
                TypeAssertionCodes.BeDerivedFrom,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be derived from '{baseType.FullName}' but it is not"
                    : $"Expected type to be derived from '{baseType.FullName}' but found null",
                e => e.With("baseType", baseType.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not derived from T.
        /// </summary>
        /// <typeparam name="TBaseClass">The type that should not be derived from.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeDerivedFrom<TBaseClass>(string because = "", params object[] becauseArgs)
            where TBaseClass : class
        {
            return NotBeDerivedFrom(typeof(TBaseClass), because, becauseArgs);
        }

        /// <summary>
        /// Asserts that the current Type is not derived from the specified base type.
        /// </summary>
        /// <param name="baseType">The type that should not be derived from.</param>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        /// <exception cref="ArgumentNullException">Thrown when baseType is null.</exception>
        /// <exception cref="ArgumentException">Thrown when baseType is an interface.</exception>
        public TSelf NotBeDerivedFrom(Type baseType, string because = "", params object[] becauseArgs)
        {
            if (baseType is null)
            {
                throw new ArgumentNullException(nameof(baseType));
            }

            if (baseType.IsInterface)
            {
                throw new ArgumentException($"'{baseType.FullName}' is an interface. Use NotImplement() instead.", nameof(baseType));
            }

            return Assert(
                s => s is null || !s.IsSubclassOf(baseType),
                TypeAssertionCodes.NotBeDerivedFrom,
                $"Expected type '{Subject?.FullName ?? "(null)"}' to not be derived from '{baseType.FullName}' but it is",
                e => e.With("baseType", baseType.FullName ?? "(null)")
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is sealed.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeSealed(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.IsSealed && s.IsClass,
                TypeAssertionCodes.BeSealed,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be sealed but it is not"
                    : "Expected type to be sealed but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not sealed.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeSealed(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && (!s.IsSealed || !s.IsClass),
                TypeAssertionCodes.NotBeSealed,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to not be sealed but it is"
                    : "Expected type to not be sealed but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is abstract.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeAbstract(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.IsAbstract && s.IsClass,
                TypeAssertionCodes.BeAbstract,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be abstract but it is not"
                    : "Expected type to be abstract but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not abstract.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeAbstract(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && (!s.IsAbstract || !s.IsClass),
                TypeAssertionCodes.NotBeAbstract,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to not be abstract but it is"
                    : "Expected type to not be abstract but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is an interface.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeInterface(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.IsInterface,
                TypeAssertionCodes.BeInterface,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be an interface but it is not"
                    : "Expected type to be an interface but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not an interface.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeInterface(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && !s.IsInterface,
                TypeAssertionCodes.NotBeInterface,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to not be an interface but it is"
                    : "Expected type to not be an interface but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is a class.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeClass(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.IsClass,
                TypeAssertionCodes.BeClass,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be a class but it is not"
                    : "Expected type to be a class but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not a class.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeClass(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && !s.IsClass,
                TypeAssertionCodes.NotBeClass,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to not be a class but it is"
                    : "Expected type to not be a class but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is decorated with the specified attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf BeDecoratedWith<TAttribute>(string because = "", params object[] becauseArgs)
            where TAttribute : Attribute
        {
            return Assert(
                s => s is not null && s.GetCustomAttributes(typeof(TAttribute), false).Any(),
                TypeAssertionCodes.BeDecoratedWith,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to be decorated with '{typeof(TAttribute).Name}' but the attribute was not found"
                    : $"Expected type to be decorated with '{typeof(TAttribute).Name}' but found null",
                e => e.With("attribute", typeof(TAttribute).Name)
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type is not decorated with the specified attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The attribute type.</typeparam>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotBeDecoratedWith<TAttribute>(string because = "", params object[] becauseArgs)
            where TAttribute : Attribute
        {
            return Assert(
                s => s is null || !s.GetCustomAttributes(typeof(TAttribute), false).Any(),
                TypeAssertionCodes.NotBeDecoratedWith,
                $"Expected type '{Subject?.FullName ?? "(null)"}' to not be decorated with '{typeof(TAttribute).Name}' but the attribute was found",
                e => e.With("attribute", typeof(TAttribute).Name)
                      .With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type has a default constructor.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf HaveDefaultConstructor(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.GetConstructor(Type.EmptyTypes) is not null,
                TypeAssertionCodes.HaveDefaultConstructor,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to have a default constructor but it does not"
                    : "Expected type to have a default constructor but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }

        /// <summary>
        /// Asserts that the current Type does not have a default constructor.
        /// </summary>
        /// <param name="because">A reason why this assertion is needed.</param>
        /// <param name="becauseArgs">Arguments for formatting the reason.</param>
        /// <returns>The assertion instance for chaining.</returns>
        public TSelf NotHaveDefaultConstructor(string because = "", params object[] becauseArgs)
        {
            return Assert(
                s => s is not null && s.GetConstructor(Type.EmptyTypes) is null,
                TypeAssertionCodes.NotHaveDefaultConstructor,
                Subject is not null
                    ? $"Expected type '{Subject.FullName}' to not have a default constructor but it does"
                    : "Expected type to not have a default constructor but found null",
                e => e.With("actual", Subject?.FullName ?? "(null)")
                      .With("reason", FormatBecause(because, becauseArgs)));
        }
    }
}
