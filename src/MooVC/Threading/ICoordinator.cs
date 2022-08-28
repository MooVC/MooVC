namespace MooVC.Threading;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface ICoordinator<T>
    where T : notnull
{
    Task<ICoordinationContext<T>> ApplyAsync(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default);
}