namespace Mu.Modelling.Behavior;

using System;
using Mu.Modelling;
using Mu.Modelling.State;

public abstract record Fact<TAggregate>
    : Fact
    where TAggregate : Aggregate
{
    private static readonly Model model = typeof(TAggregate);

    protected Fact()
    {
    }

    protected Fact(Guid identity, DateTimeOffset proposed)
        : base(identity, proposed)
    {
    }

    public override Model Model => model;
}