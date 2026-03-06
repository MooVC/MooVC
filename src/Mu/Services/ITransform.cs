namespace Mu.Services;

using Mu.Modelling.Behavior;
using Mu.Modelling.State;

/// <summary>
/// Mutates the <see cref="TAggregae"/>, resulting in a new instance of the aggregate with the changes applied.
/// </summary>
/// <typeparam name="TAggregae">The type of the <see cref="Aggregate"/> to which the mutation is applied.</typeparam>
/// <typeparam name="TFact">The <see cref="Fact"/> type associated with the change that has occurred.</typeparam>
public interface ITransform<TAggregae, in TFact>
    where TAggregae : Aggregate
    where TFact : Fact
{
    TAggregae Apply(TAggregae aggregate, TFact fact);
}