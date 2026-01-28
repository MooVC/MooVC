namespace Mu.Communications.Messaging;

using Mu.Communications.Tracing;
using Mu.Modelling.Behavior;

public abstract record Event
    : Message
{
    private protected Event(DateTimeOffset committedAt, Ledger context, Fact fact, DateTimeOffset preparedAt)
        : base(context, preparedAt)
    {
        ArgumentNullException.ThrowIfNull(fact);

        CommittedAt = committedAt;
        Fact = fact;
    }

    public DateTimeOffset CommittedAt { get; }

    public Fact Fact { get; }
}