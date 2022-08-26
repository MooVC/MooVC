namespace MooVC.Threading;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface ICoordinator
{
    Task<ICoordinationContext<T>> ApplyAsync<T>(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default)
        where T : notnull;
}