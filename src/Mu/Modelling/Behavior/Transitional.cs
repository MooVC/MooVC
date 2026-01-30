namespace Mu.Modelling.Behavior;

public abstract record Transitional
    : Mutational
{
    private protected Transitional()
    {
    }

    private protected Transitional(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}