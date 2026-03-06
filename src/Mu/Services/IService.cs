namespace Mu.Services;

/// <summary>
/// Fine grain orchestrator of a usecase.
/// </summary>
/// <typeparam name="TUseCase">The <see cref="UseCase"/> type being orchestrated.</typeparam>
/// <typeparam name="TResult">The expected result from the execution of the usecase.</typeparam>
public interface IService<in TUseCase, TResult>
    where TResult : notnull
{
    Task<Result<TResult>> Execute(TUseCase useCase, CancellationToken cancellationToken);
}