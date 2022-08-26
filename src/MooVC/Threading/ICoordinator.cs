namespace MooVC.Threading;

using System;
using System.Threading;

public interface ICoordinator
{
    ICoordinationContext<T> ApplyAsync<T>(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default)
        where T : notnull;
}