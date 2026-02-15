using System;
using System.Linq;

namespace Ave.Extensions.FluentContracts
{
    /// <summary>
    /// Auto-detects the active test framework and throws framework-specific exceptions.
    /// Detection runs once on first failure and caches the result.
    /// No compile-time dependency on any test framework.
    /// </summary>
    internal static class TestFrameworkDetector
    {
        private static readonly (string AssemblyName, string ExceptionType)[] Known = new[]
        {
            ("nunit.framework", "NUnit.Framework.AssertionException"),
            ("xunit.assert", "Xunit.Sdk.XunitException"),
            ("xunit.v3.assert", "Xunit.Sdk.XunitException"),
            ("Microsoft.VisualStudio.TestPlatform.TestFramework", "Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException"),
            ("tunit.assertions", "TUnit.Assertions.Exceptions.AssertionException"),
        };

        private static Func<string, Exception>? _cached;

        /// <summary>
        /// Throws a framework-specific contract exception with the given message.
        /// </summary>
        /// <param name="message">The contract failure message.</param>
        internal static void Throw(string message)
        {
            var factory = _cached ?? (_cached = Detect());
            throw factory(message);
        }

        private static Func<string, Exception> Detect()
        {
            foreach (var (assemblyName, exceptionTypeName) in Known)
            {
                var assembly = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .FirstOrDefault(a => string.Equals(
                        a.GetName().Name, assemblyName, StringComparison.OrdinalIgnoreCase));

                var exceptionType = assembly?.GetType(exceptionTypeName);

                if (exceptionType is not null)
                {
                    return msg => (Exception)Activator.CreateInstance(exceptionType, msg)!;
                }
            }

            return msg => new ContractViolationException(msg);
        }
    }
}
