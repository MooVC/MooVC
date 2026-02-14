namespace Mu.Services;

using Mu.Modelling.Behavior;
using Mu.Modelling.State;

public interface ITransform<TAggregae, in TFact>
    where TAggregae : Aggregate
    where TFact : Fact
{
    TAggregae Apply(TAggregae aggregate, TFact fact);
}