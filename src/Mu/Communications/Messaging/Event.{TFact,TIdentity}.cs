namespace Mu.Communications.Messaging;

using System.Text.Json.Serialization;
using Mu.Communications.Tracing;
using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public sealed record Event<TFact, TIdentity>
    : Event
    where TFact : Fact
    where TIdentity : struct
{
    [JsonConstructor]
    internal Event(DateTimeOffset committedAt, Ledger context, TFact fact, Reference<TIdentity> origin, DateTimeOffset preparedAt)
        : base(committedAt, context, fact, preparedAt)
    {
        Fact = fact;
        Origin = origin;
    }

    public new TFact Fact { get; }

    public Reference<TIdentity> Origin { get; }
}