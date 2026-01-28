namespace Mu.Modelling.Behavior;

using Mu.Modelling;
using Mu.Modelling.State;

public abstract record Transitional<TAggregate, TIdentity>
    : Transitional
    where TAggregate : Aggregate
    where TIdentity : struct
{
    private static readonly Model model = typeof(TAggregate);

    protected Transitional(Reference<TIdentity> target)
    {
        Target = target;
    }

    protected Transitional(Guid identity, DateTimeOffset proposed, Reference<TIdentity> target)
        : base(identity, proposed)
    {
        Target = target;
    }

    public Reference<TIdentity> Target { get; }

    public override Model Model => model;
}