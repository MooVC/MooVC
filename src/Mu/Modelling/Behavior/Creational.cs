namespace Mu.Modelling.Behavior;

public abstract record Creational
    : Mutational
{
    private protected Creational()
    {
    }

    private protected Creational(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}