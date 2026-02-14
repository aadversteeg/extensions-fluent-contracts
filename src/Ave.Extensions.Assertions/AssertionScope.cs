using System;
using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.Assertions
{
    /// <summary>
    /// Provides collection mode for gathering multiple assertion failures.
    /// </summary>
    public static class AssertionScope
    {
        /// <summary>
        /// Executes multiple assertions and collects all failures instead of short-circuiting.
        /// </summary>
        /// <param name="assertions">The assertion functions to execute. Each should return a VoidResult.</param>
        /// <returns>A Result containing Unit on success, or a list of all errors on failure.</returns>
        public static Result<Unit, IReadOnlyList<Error>> All(
            params Func<VoidResult<Error>>[] assertions)
        {
            var errors = new List<Error>();

            foreach (var assertion in assertions)
            {
                var result = assertion();
                if (result.IsFailure)
                {
                    errors.Add(result.Error);
                }
            }

            return errors.Count == 0
                ? Result<Unit, IReadOnlyList<Error>>.Success(Unit.Value)
                : Result<Unit, IReadOnlyList<Error>>.Failure(errors);
        }
    }
}
