namespace Mu.Communications.Mediation;

using Mu.Modelling.Behavior;

public interface IMediator
{
    Task<Result<TResult>> Execute<TUseCase, TResult>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase
        where TResult : notnull;
}