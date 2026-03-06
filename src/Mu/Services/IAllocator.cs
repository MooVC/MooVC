namespace Mu.Services;

using System.Threading.Tasks;
using Mu.Modelling.Behavior;

public interface IAllocator<TIdentity>
    where TIdentity : struct
{
    Task<TIdentity> Allocate<TUseCase>(TUseCase useCase, CancellationToken cancellationToken)
        where TUseCase : UseCase;
}