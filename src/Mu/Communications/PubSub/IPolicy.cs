namespace Mu.Communications.PubSub;

using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;

public interface IPolicy<TFact, TIdentity>
    where TFact : Fact
    where TIdentity : struct
{
    Task Handle(Event<TFact, TIdentity> @event, CancellationToken cancellationToken);
}