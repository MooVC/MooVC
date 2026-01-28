namespace Mu.Communications.Mediation;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;

public sealed class Mediator(IComposer composer, IServiceProvider provider)
    : IMediator
{
    public async Task<Result<TResult>> Execute<TUseCase, TResult>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase
        where TResult : notnull
    {
        IHandler<TUseCase, TResult> handler = provider.GetRequiredService<IHandler<TUseCase, TResult>>();

        Intent<TUseCase> intent = await composer
            .Express(useCase, cancellationToken)
            .ConfigureAwait(false);

        return await handler
            .Handle(intent, cancellationToken)
            .ConfigureAwait(false);
    }
}