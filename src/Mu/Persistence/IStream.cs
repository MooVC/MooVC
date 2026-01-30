namespace Mu.Persistence;

using System.Collections.Immutable;
using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public interface IStream<TIdentity>
    where TIdentity : struct
{
    /// <returns>The time at which the facts are deemed to be committed to the stream.</returns>
    Task<DateTimeOffset> Append(IEnumerable<Fact> facts, TIdentity identity, Revision revision, CancellationToken cancellationToken);

    /// <returns>The time at which the facts are deemed to be committed to the stream.</returns>
    Task<DateTimeOffset> Initiate(IEnumerable<Fact> facts, TIdentity identity, CancellationToken cancellationToken);

    Task<ImmutableArray<Event>> Find(FindOptions options, CancellationToken cancellationToken);

    public sealed record FindOptions(
        ImmutableArray<Type> Facts = default,
        Range<DateTimeOffset> Committed = default,
        Range<DateTimeOffset> Proposed = default,
        Range<ulong> Revision = default,
        TIdentity Identity = default);
}