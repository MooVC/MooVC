namespace Mu.Modelling.Behavior;

public abstract record UseCase
    : Causal
{
    private protected UseCase()
    {
    }

    private protected UseCase(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}