namespace Mu.Services;

public interface IService<in TUseCase, TResult>
    where TResult : notnull
{
    Task<Result<TResult>> Execute(TUseCase useCase, CancellationToken cancellationToken);
}