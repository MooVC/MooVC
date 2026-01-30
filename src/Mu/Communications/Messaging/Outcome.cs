namespace Mu.Communications.Messaging;

using System.Text.Json.Serialization;
using Mu.Communications.Tracing;

public sealed record Outcome<TResult>
    : Message
    where TResult : notnull
{
    internal Outcome(Ledger ledger, Result<TResult> result)
        : this(ledger, DateTimeOffset.UtcNow, result)
    {
    }

    [JsonConstructor]
    internal Outcome(Ledger ledger, DateTimeOffset preparedAt, Result<TResult> result)
        : base(ledger, preparedAt)
    {
        Result = result;
    }

    public Result<TResult> Result { get; }

    public static implicit operator Result<TResult>(Outcome<TResult> response)
    {
        return response.Result;
    }
}