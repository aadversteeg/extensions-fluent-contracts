using System;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Extension methods providing Should() entry points for Action delegates.
    /// </summary>
    public static class ActionContractExtensions
    {
        /// <summary>
        /// Returns an <see cref="ActionContracts"/> object for checking contracts on the specified Action.
        /// Contract failures are recorded and returned as Result errors.
        /// </summary>
        /// <param name="subject">The Action to check.</param>
        /// <returns>An <see cref="ActionContracts"/> instance.</returns>
        public static ActionContracts Should(this Action subject)
        {
            return new ActionContracts(subject);
        }

        /// <summary>
        /// Creates an Action that invokes an action on the specified subject.
        /// This allows for fluent exception contract syntax.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="subject">The subject to invoke the action on.</param>
        /// <param name="action">The action to invoke.</param>
        /// <returns>An Action that can be used with Should().Throw() contracts.</returns>
        /// <example>
        /// <code>
        /// var result = subject.Invoking(s => s.DoSomething()).Should().Throw&lt;InvalidOperationException&gt;();
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
        /// This allows for fluent exception contract syntax where the method returns a value.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="TResult">The return type of the function.</typeparam>
        /// <param name="subject">The subject to invoke the function on.</param>
        /// <param name="func">The function to invoke.</param>
        /// <returns>An Action that can be used with Should().Throw() contracts.</returns>
        /// <example>
        /// <code>
        /// var result = subject.Invoking(s => s.GetValue()).Should().Throw&lt;InvalidOperationException&gt;();
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
