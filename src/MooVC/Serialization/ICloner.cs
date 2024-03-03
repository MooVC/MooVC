namespace MooVC.Serialization;

/// <summary>
/// Defines a contract for cloning objects.
/// </summary>
public interface ICloner
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
    Task<T> Clone<T>(T original, CancellationToken cancellationToken)
        where T : notnull;
}