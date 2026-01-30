namespace Mu.Services;

using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public static partial class ITransformExtensions
{
    public static TAggregate ApplyAll<TAggregate, TFact>(
        this ITransform<TAggregate, TFact> transform,
        TAggregate aggregate,
        params IEnumerable<TFact> facts)
        where TAggregate : Aggregate
        where TFact : Fact
    {
        IEnumerable<ITransform<TAggregate, TFact>> transforms = [transform];

        return transforms.ApplyAll(aggregate, facts);
    }

    public static TAggregate ApplyAll<TAggregate, TFact>(
        this IEnumerable<ITransform<TAggregate, TFact>> transforms,
        TAggregate aggregate,
        params IEnumerable<TFact> facts)
        where TAggregate : Aggregate
        where TFact : Fact
    {
        foreach (TFact fact in facts)
        {
            foreach (ITransform<TAggregate, TFact> transform in transforms)
            {
                aggregate = transform.Apply(aggregate, fact);
            }
        }

        return aggregate;
    }
}