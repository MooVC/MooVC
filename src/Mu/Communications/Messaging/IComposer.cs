namespace Mu.Communications.Messaging;

using System.Threading.Tasks;
using Mu.Modelling.Behavior;

public interface IComposer
{
    ValueTask<Intent<TUseCase>> Express<TUseCase>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase;

    ValueTask<Event<TFact, TIdentity>> Raise<TFact, TIdentity>(TFact fact, TIdentity identity, CancellationToken cancellationToken)
        where TFact : Fact
        where TIdentity : struct;

    ValueTask<Outcome<TResult>> Yield<TResult>(TResult result, CancellationToken cancellationToken)
        where TResult : notnull;
}