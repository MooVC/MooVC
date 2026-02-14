namespace Mu.Modelling.Behavior;

using Mu.Modelling;

public abstract record Causal
{
    private protected Causal()
        : this(DateTimeOffset.UtcNow)
    {
    }

    private protected Causal(Guid identity, DateTimeOffset proposed)
    {
        Identity = identity;
        Proposed = proposed;
    }

    private Causal(DateTimeOffset proposed)
        : this(Guid.CreateVersion7(proposed), proposed)
    {
    }

    public Guid Identity { get; }

    public DateTimeOffset Proposed { get; }

    public abstract Model Model { get; }
}