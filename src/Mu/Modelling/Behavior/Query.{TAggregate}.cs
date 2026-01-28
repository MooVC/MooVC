namespace Mu.Modelling.Behavior;

using Mu.Modelling;
using Mu.Modelling.State;

public abstract record Query<TAggregate>
    : Query
    where TAggregate : Aggregate
{
    private static readonly Model model = typeof(TAggregate);

    protected Query()
    {
    }

    protected Query(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }

    public override Model Model => model;
}