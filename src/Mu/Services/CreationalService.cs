namespace Mu.Services;

using System.Linq;
using System.Threading.Tasks;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;
using Mu.Persistence;

public sealed class CreationalService<TAggregate, TIdentity, TUseCase>(
    IAllocator<TIdentity> allocator,
    IRoot<TAggregate, TUseCase> root,
    IWriteStore<TAggregate, TIdentity> store)
    : IService<TUseCase, TIdentity>
    where TAggregate : Aggregate, new()
    where TIdentity : struct
    where TUseCase : Creational
{
    public async Task<Result<TIdentity>> Execute(TUseCase useCase, CancellationToken cancellationToken)
    {
        TIdentity identity = await allocator
            .Allocate(useCase, cancellationToken)
            .ConfigureAwait(false);

        var aggregate = new TAggregate();

        return await root
            .Apply(aggregate, useCase, cancellationToken)
            .Then(opened => store.Save(aggregate, identity, cancellationToken))
            .Select(_ => identity)
            .ConfigureAwait(false);
    }
}