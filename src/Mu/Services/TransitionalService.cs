namespace Mu.Services;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;
using Mu.Persistence;

public sealed class TransitionalService<TAggregate, TIdentity, TUseCase>(
    IRoot<TAggregate, TUseCase> root,
    IWriteStore<TAggregate, TIdentity> store)
    : IService<TUseCase, Revision>
    where TAggregate : Aggregate, new()
    where TIdentity : struct
    where TUseCase : Transitional<TAggregate, TIdentity>
{
    public async Task<Result<Revision>> Execute(TUseCase useCase, CancellationToken cancellationToken)
    {
        TAggregate? aggregate = await store
            .Get(useCase.Target.Identity, useCase.Target.Revision, cancellationToken)
            .ConfigureAwait(false);

        if (aggregate is null)
        {
            return new ValidationResult($"`{typeof(TAggregate)}` `{useCase.Target}` does not exit.");
        }

        return await root
            .Apply(aggregate, useCase, cancellationToken)
            .Then(opened => store.Save(aggregate, useCase.Target.Identity, cancellationToken))
            .Select(_ => aggregate.Revision)
            .ConfigureAwait(false);
    }
}