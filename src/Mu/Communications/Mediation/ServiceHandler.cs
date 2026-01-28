namespace Mu.Communications.Mediation;

using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;
using Mu.Services;

public sealed class ServiceHandler<TUseCase, TResult>(IService<TUseCase, TResult> service)
    : IHandler<TUseCase, TResult>
    where TUseCase : UseCase
    where TResult : notnull
{
    public async Task<Outcome<TResult>> Handle(Intent<TUseCase> intent, CancellationToken cancellationToken)
    {
        Result<TResult> result = await service
            .Execute(intent.UseCase, cancellationToken)
            .ConfigureAwait(false);

        return intent.Yields(result);
    }
}