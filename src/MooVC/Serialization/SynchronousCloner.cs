namespace MooVC.Serialization;

/// <summary>
/// Faciliates implementation of a synchronous implementation of the <see cref="ICloner" /> contract for cloning objects.
/// </summary>
public abstract class SynchronousCloner
    : ICloner
{
    /// <summary>
    /// Asynchronously clones the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="original">The original object to clone.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous clone operation.
    /// The task result contains the cloned object.
    /// </returns>
    public Task<T> Clone<T>(T original, CancellationToken cancellationToken)
        where T : notnull
    {
        return Task.FromResult(PerformClone(original));
    }

    /// <summary>
    /// Facilitates synchronously cloning of the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="original">The original object to clone.</param>
    /// <returns>The cloned object.</returns>
    protected abstract T PerformClone<T>(T original)
        where T : notnull;
}