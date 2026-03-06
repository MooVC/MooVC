namespace Mu.Communications.Tracing;

using Mu.Modelling.Behavior;

public sealed class Scope
    : IDisposable
{
    private static readonly AsyncLocal<Ledger?> _current = new();
    private readonly Ledger? _previous;

    public Scope(UseCase useCase)
        : this(GetLedger(useCase))
    {
    }

    public Scope(Ledger ledger)
    {
        _previous = _current.Value;
        _current.Value = Ledger = ledger;
    }

    public Ledger Ledger { get; }

    public void Dispose()
    {
        _current.Value = _previous;
    }

    private static Ledger GetLedger(UseCase useCase)
    {
        ArgumentNullException.ThrowIfNull(useCase);

        Ledger? current = _current.Value;

        if (current.HasValue)
        {
            return current.Value.Next(useCase.Identity);
        }

        return new Ledger(useCase.Identity);
    }
}