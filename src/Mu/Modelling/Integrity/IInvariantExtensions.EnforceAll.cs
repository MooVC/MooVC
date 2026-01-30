namespace Mu.Modelling.Integrity;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public static partial class IInvariantExtensions
{
    public static async Task<ImmutableArray<ValidationResult>> EnforceAll<TAggregate, TIntent>(
        this IEnumerable<IInvariant<TAggregate, TIntent>> invariants,
        TAggregate aggregate,
        TIntent intent,
        CancellationToken cancellationToken)
        where TAggregate : Aggregate
        where TIntent : Mutational
    {
        var failures = new List<ValidationResult>();

        foreach (IInvariant<TAggregate, TIntent> invariant in invariants)
        {
            await foreach (ValidationResult failure in invariant.Enforce(aggregate, intent, cancellationToken))
            {
                failures.AddRange(failure);
            }
        }

        return [.. failures];
    }
}