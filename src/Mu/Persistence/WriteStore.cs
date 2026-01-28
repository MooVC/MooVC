namespace Mu.Persistence;

using System.Collections.Immutable;
using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;
using Mu.Services;

public sealed class WriteStore<TAggregate, TIdentity>(IStream<TIdentity> stream, ITransform<TAggregate, Fact> transform)
    : IWriteStore<TAggregate, TIdentity>
    where TAggregate : Aggregate, new()
    where TIdentity : struct
{
    public async Task<TAggregate?> Get(TIdentity identity, ulong revision, CancellationToken cancellationToken)
    {
        ImmutableArray<Event> events = await stream
            .Find(
                new()
                {
                    Identity = identity,
                    Revision = (From: 1ul, To: revision),
                },
                cancellationToken)
            .ConfigureAwait(false);

        if (events.Length == 0)
        {
            return default;
        }

        IEnumerable<Fact> facts = events.Select(@event => @event.Fact);
        TAggregate aggregate = new();

        aggregate = transform.ApplyAll(aggregate, facts);

        return aggregate;
    }

    public async Task Save(TAggregate aggregate, TIdentity identity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(aggregate);

        if (!aggregate.HasChanges)
        {
            return;
        }

        _ = await stream
            .Append(aggregate.Propositions, identity, aggregate.Revision, cancellationToken)
            .ConfigureAwait(false);
    }
}