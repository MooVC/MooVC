namespace MooVC.Threading;

using System;
using System.Threading;

internal sealed class CoordinationContext<T>
    : ICoordinationContext<T>
    where T : notnull
{
    private readonly SemaphoreSlim semaphore;
    private TimeSpan? disposal;

    public CoordinationContext(T context, SemaphoreSlim semaphore)
    {
        Context = context;
        this.semaphore = semaphore;
    }

    public T Context { get; }

    public TimeSpan Duration => disposal ?? DateTimeOffset.UtcNow.Subtract(TimeStamp);

    public DateTimeOffset TimeStamp { get; } = DateTimeOffset.UtcNow;

    public void Dispose()
    {
        Dispose(disposing: true);

        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposal.HasValue)
        {
            if (disposing)
            {
                _ = semaphore.Release();
            }

            disposal = Duration;
        }
    }
}