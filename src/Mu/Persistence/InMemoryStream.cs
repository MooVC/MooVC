namespace Mu.Persistence;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

internal sealed class InMemoryStream<TIdentity>
    : IStream<TIdentity>
    where TIdentity : struct
{
    public Task<DateTimeOffset> Append(IEnumerable<Fact> facts, TIdentity identity, Revision revision, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ImmutableArray<Event>> Find(IStream<TIdentity>.FindOptions options, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DateTimeOffset> Initiate(IEnumerable<Fact> facts, TIdentity identity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}