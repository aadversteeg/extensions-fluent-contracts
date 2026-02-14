using System;

namespace Ave.Extensions.Assertions.Exceptions
{
    /// <summary>
    /// Extension methods providing Should() and Must() entry points for Action delegates.
    /// </summary>
    public static class ActionAssertionExtensions
    {
        /// <summary>
        /// Returns an <see cref="ActionAssertions"/> object for asserting on the specified Action.
        /// Assertion failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Action to assert on.</param>
        /// <returns>An <see cref="ActionAssertions"/> instance.</returns>
        public static ActionAssertions Should(this Action subject)
        {
            return new ActionAssertions(subject);
        }

        /// <summary>
        /// Returns a <see cref="MustActionAssertions"/> object for asserting on the specified Action.
        /// Assertion failures throw framework-specific exceptions.
        /// </summary>
        /// <param name="subject">The Action to assert on.</param>
        /// <returns>A <see cref="MustActionAssertions"/> instance.</returns>
        public static MustActionAssertions Must(this Action subject)
        {
            return new MustActionAssertions(subject);
        }

        /// <summary>
        /// Creates an Action that invokes an action on the specified subject.
        /// This allows for fluent exception assertion syntax.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="subject">The subject to invoke the action on.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>An Action that can be used with Should().Throw() or Must().Throw() assertions.</returns>
        /// <example>
        /// <code>
        /// var result = subject.Invoking(s => s.DoSomething()).Should().Throw&lt;InvalidOperationException&gt;();
        /// subject.Invoking(s => s.DoSomething()).Must().Throw&lt;InvalidOperationException&gt;();
        /// </code>
        /// </example>
        public static Action Invoking<T>(this T subject, Action<T> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return () => action(subject);
        }

        /// <summary>
        /// Creates an Action that invokes a function on the specified subject.
        /// This allows for fluent exception assertion syntax where the method returns a value.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="TResult">The return type of the function.</typeparam>
        /// <param name="subject">The subject to invoke the function on.</param>
        /// <param name="func">The function to invoke.</param>
        /// <returns>An Action that can be used with Should().Throw() or Must().Throw() assertions.</returns>
        /// <example>
        /// <code>
        /// var result = subject.Invoking(s => s.GetValue()).Should().Throw&lt;InvalidOperationException&gt;();
        /// subject.Invoking(s => s.GetValue()).Must().Throw&lt;InvalidOperationException&gt;();
        /// </code>
        /// </example>
        public static Action Invoking<T, TResult>(this T subject, Func<T, TResult> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return () => func(subject);
        }
    }
}
