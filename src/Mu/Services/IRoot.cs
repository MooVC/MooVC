namespace Mu.Services;

using Mu.Modelling.Behavior;
using Mu.Modelling.State;

/// <summary>
/// Orchestrates the enforcement of the invariants associated with the <typeparamref name="TAggregate"/> for the proposed <typeparamref name="TMutation"/>.
/// If the invariants are upheld, the transforms associated with the mutation will be applied.
/// </summary>
/// <typeparam name="TAggregate">The concrete type of the <see cref="Aggregate"/>.</typeparam>
/// <typeparam name="TMutation">The concrete type of the <see cref="Mutational"/>.</typeparam>
public interface IRoot<TAggregate, in TMutation>
    where TAggregate : Aggregate
    where TMutation : Mutational
{
    Task<Result<TAggregate>> Apply(TAggregate aggregate, TMutation mutation, CancellationToken cancellationToken);
}