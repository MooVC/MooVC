namespace Mu.Modelling.Behavior;

public abstract record Mutational
    : UseCase
{
    private protected Mutational()
    {
    }

    private protected Mutational(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}