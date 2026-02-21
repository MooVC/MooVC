namespace Mu.Modelling.Behavior;

public abstract record Query
    : NonMutational
{
    private protected Query()
    {
    }

    private protected Query(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }
}