namespace Mu.Modelling.State;

using Mu.Modelling.Behavior;
using Mu.Services;

public static partial class AggregateExtensions
{
    public static TAggregate Propose<TAggregate, TFact>(
        this TAggregate aggregate,
        TFact fact,
        params IEnumerable<ITransform<TAggregate, TFact>> transforms)
        where TAggregate : Aggregate
        where TFact : Fact<TAggregate>
    {
        ArgumentNullException.ThrowIfNull(aggregate);
        ArgumentNullException.ThrowIfNull(fact);

        aggregate = aggregate with
        {
            Propositions = [.. aggregate.Propositions, fact],
        };

        return transforms.ApplyAll(aggregate, fact);
    }
}