namespace MooVC.Threading.Coordination;

/// <summary>
/// Represents the context in which coordination has been applied.
/// </summary>
/// <typeparam name="T">The type in which the coordination context applies.</typeparam>
internal sealed class Context<T>
    : IContext<T>
    where T : notnull
{
    private readonly SemaphoreSlim _semaphore;
    private TimeSpan? _disposal;

    /// <summary>
    /// Initializes a new instance of the <see cref="Context{T}" /> class.
    /// </summary>
    /// <param name="subject">The instance on which coordination has been applied.</param>
    /// <param name="semaphore">The semaphore used to apply coordination.</param>
    public Context(SemaphoreSlim semaphore, T subject)
    {
        _semaphore = semaphore;
        Subject = subject;
    }

    /// <summary>
    /// Gets the duration for which coordination has been applied.
    /// </summary>
    /// <value>
    /// The duration for which coordination has been applied.
    /// </value>
    public TimeSpan Duration => _disposal ?? DateTimeOffset.UtcNow.Subtract(TimeStamp);

    /// <summary>
    /// Gets the instance on which coordination has been applied.
    /// </summary>
    /// <value>
    /// The instance on which coordination has been applied.
    /// </value>
    public T Subject { get; }

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
        if (!_disposal.HasValue)
        {
            if (disposing)
            {
                _ = _semaphore.Release();
            }

            _disposal = Duration;
        }
    }
}