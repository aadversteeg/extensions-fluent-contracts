using System;
using System.Collections.Generic;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Ave.Extensions.FluentContracts.ForValidation
{
    /// <summary>
    /// Provides collection mode for gathering multiple contract failures.
    /// </summary>
    public static class ContractScope
    {
        /// <summary>
        /// Executes multiple contracts and collects all failures instead of short-circuiting.
        /// </summary>
        /// <param name="contracts">The contract functions to execute. Each should return a VoidResult.</param>
        /// <returns>A Result containing Unit on success, or a list of all errors on failure.</returns>
        public static Result<Unit, IReadOnlyList<Error>> All(
            params Func<VoidResult<Error>>[] contracts)
        {
            var errors = new List<Error>();

            foreach (var contract in contracts)
            {
                var result = contract();
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
