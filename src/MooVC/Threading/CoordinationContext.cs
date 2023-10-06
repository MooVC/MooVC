namespace MooVC.Threading;

using System;
using System.Threading;

/// <summary>
/// Represents the context in which coordination has been applied.
/// </summary>
/// <typeparam name="T">The type in which the coordination context applies.</typeparam>
internal sealed class CoordinationContext<T>
    : ICoordinationContext<T>
    where T : notnull
{
    private readonly SemaphoreSlim semaphore;
    private TimeSpan? disposal;

    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinationContext{T}" /> class.
    /// </summary>
    /// <param name="context">The instance on which coordination has been applied.</param>
    /// <param name="semaphore">The semaphore used to apply coordination.</param>
    public CoordinationContext(T context, SemaphoreSlim semaphore)
    {
        Context = context;
        this.semaphore = semaphore;
    }

    /// <summary>
    /// Gets the instance on which coordination has been applied.
    /// </summary>
    /// <value>
    /// The instance on which coordination has been applied.
    /// </value>
    public T Context { get; }

    /// <summary>
    /// Gets the duration for which coordination has been applied.
    /// </summary>
    /// <value>
    /// The duration for which coordination has been applied.
    /// </value>
    public TimeSpan Duration => disposal ?? DateTimeOffset.UtcNow.Subtract(TimeStamp);

    /// <summary>
    /// Gets the timestamp when the coordination started.
    /// </summary>
    /// <value>
    /// The timestamp when the coordination started.
    /// </value>
    public DateTimeOffset TimeStamp { get; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Releases coordination on the <see cref="Context" /> and sets the final <see cref="Duration" /> for which it was held.
    /// </summary>
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