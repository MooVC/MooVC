namespace Mu.Communications.Mediation;

using Mu.Modelling.Behavior;

/// <summary>
/// The service responsible for the execution of a usecase, by delegating the handling of the usecase to the appropriate handler.
/// </summary>
public interface IMediator
{
    Task<Result<TResult>> Execute<TUseCase, TResult>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase
        where TResult : notnull;
}