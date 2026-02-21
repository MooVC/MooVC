namespace Mu.Modelling.Integrity;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public abstract class Invariant<TAggregate, TIntent>
    : IInvariant<TAggregate, TIntent>
    where TAggregate : Aggregate
    where TIntent : Mutational
{
    public IAsyncEnumerable<ValidationResult> Enforce(TAggregate aggregate, TIntent mutation, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(aggregate);
        ArgumentNullException.ThrowIfNull(mutation);

        return PerformEnforce(aggregate, mutation, cancellationToken);
    }

    protected abstract IAsyncEnumerable<ValidationResult> PerformEnforce(TAggregate aggregate, TIntent mutation, CancellationToken cancellationToken);
}