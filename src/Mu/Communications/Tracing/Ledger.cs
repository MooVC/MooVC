namespace Mu.Communications.Tracing;

using System.Text.Json.Serialization;

public readonly record struct Ledger
{
    internal Ledger(Guid causation)
        : this(causation, causation)
    {
    }

    [JsonConstructor]
    internal Ledger(Guid causation, Guid correlation)
    {
        Causation = causation;
        Correlation = correlation;
    }

    public Guid Causation { get; }

    public Guid Correlation { get; }

    public bool IsInitiator => Causation == Correlation;

    public Ledger Next(Guid causation)
    {
        return new Ledger(causation, Correlation);
    }
}