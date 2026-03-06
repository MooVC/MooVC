namespace Mu.Communications.Mediation;

using Mu.Communications.Messaging;
using Mu.Modelling.Behavior;

/// <summary>
/// Coarse grain interface for the handling of a usecase.
/// </summary>
/// <typeparam name="TUseCase">The <see cref="UseCase"/> type handled by this handler.</typeparam>
/// <typeparam name="TResult">The expected result from the execution of the usecase.</typeparam>
public interface IHandler<TUseCase, TResult>
    where TUseCase : UseCase
    where TResult : notnull
{
    Task<Outcome<TResult>> Handle(Intent<TUseCase> intent, CancellationToken cancellationToken);
}