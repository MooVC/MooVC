namespace Mu.Communications.Messaging;

using System;
using Mu.Communications.Tracing;

public abstract record Message
{
    private protected Message(Ledger ledger)
        : this(ledger, DateTimeOffset.UtcNow)
    {
    }

    private protected Message(Ledger ledger, DateTimeOffset preparedAt)
    {
        Ledger = ledger;
        PreparedAt = preparedAt;
    }

    public Ledger Ledger { get; }

    public DateTimeOffset PreparedAt { get; }
}