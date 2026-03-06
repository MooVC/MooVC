namespace Mu.Communications.Mediation;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Mu.Communications.Messaging;
using Mu.Communications.Tracing;
using Mu.Modelling.Behavior;

public sealed class Mediator(IServiceProvider provider)
    : IMediator
{
    public async Task<Result<TResult>> Execute<TUseCase, TResult>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase
        where TResult : notnull
    {
        using var scope = new Scope(useCase);

        IHandler<TUseCase, TResult> handler = provider.GetRequiredService<IHandler<TUseCase, TResult>>();

        var intent = new Intent<TUseCase>(scope.Ledger, useCase);

        return await handler
            .Handle(intent, cancellationToken)
            .ConfigureAwait(false);
    }
}