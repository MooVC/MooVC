namespace Mu.Modelling.Behavior;

using Mu.Modelling;
using Mu.Modelling.State;

public abstract record Creational<TAggregate>
    : Creational
    where TAggregate : Aggregate
{
    private static readonly Model model = typeof(TAggregate);

    protected Creational()
    {
    }

    protected Creational(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }

    public override Model Model => model;
}