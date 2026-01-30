namespace Mu.Modelling.Integrity;

using System.ComponentModel.DataAnnotations;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public interface IInvariant<in TAggregate, in TIntent>
    where TAggregate : Aggregate
    where TIntent : Mutational
{
    IAsyncEnumerable<ValidationResult> Enforce(TAggregate aggregate, TIntent mutation, CancellationToken cancellationToken);
}