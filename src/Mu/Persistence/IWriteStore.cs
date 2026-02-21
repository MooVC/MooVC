namespace Mu.Persistence;

using Mu.Modelling.State;

public interface IWriteStore<TAggregate, TIdentity>
    where TAggregate : Aggregate
    where TIdentity : struct
{
    Task<TAggregate?> Get(TIdentity identity, ulong revision, CancellationToken cancellationToken);

    Task Save(TAggregate aggregate, TIdentity identity, CancellationToken cancellationToken);
}