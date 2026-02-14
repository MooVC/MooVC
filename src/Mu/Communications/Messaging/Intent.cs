namespace Mu.Communications.Messaging;

using System;
using System.Text.Json.Serialization;
using Mu.Communications.Tracing;
using Mu.Modelling.Behavior;

public sealed record Intent<TUseCase>
    : Message
    where TUseCase : UseCase
{
    internal Intent(Ledger ledger, TUseCase useCase)
        : this(ledger, DateTimeOffset.UtcNow, useCase)
    {
    }

    [JsonConstructor]
    internal Intent(Ledger ledger, DateTimeOffset preparedAt, TUseCase useCase)
        : base(ledger, preparedAt)
    {
        ArgumentNullException.ThrowIfNull(useCase);

        UseCase = useCase;
    }

    public TUseCase UseCase { get; }

    public static implicit operator TUseCase(Intent<TUseCase> request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return request.UseCase;
    }

    public Outcome<TResult> Yields<TResult>(Result<TResult> result)
        where TResult : notnull
    {
        Ledger ledger = Ledger.Next(UseCase.Identity);

        return new(ledger, result);
    }
}