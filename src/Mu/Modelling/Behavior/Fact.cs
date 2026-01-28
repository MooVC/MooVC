namespace Mu.Modelling.Behavior;

public abstract record Fact
    : Causal
{
    private protected Fact()
    {
    }

    private protected Fact(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}