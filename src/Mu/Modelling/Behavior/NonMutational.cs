namespace Mu.Modelling.Behavior;

public abstract record NonMutational
    : UseCase
{
    private protected NonMutational()
    {
    }

    private protected NonMutational(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}