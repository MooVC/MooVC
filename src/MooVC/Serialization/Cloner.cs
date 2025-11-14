namespace MooVC.Serialization;

using Ardalis.GuardClauses;
using static MooVC.Serialization.Cloner_Resources;

/// <summary>
/// Defines a default implementation of the <see cref="ICloner" /> interface, supporting object cloning via <see cref="ISerializer" />.
/// </summary>
public sealed class Cloner
    : ICloner
{
    private readonly ISerializer _serializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cloner" /> class with the specified <see cref="ISerializer" />.
    /// </summary>
    /// <param name="serializer">The serializer to use for cloning objects.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="serializer" /> is <see langword="null" />.</exception>
    public Cloner(ISerializer serializer)
    {
        _serializer = Guard.Against.Null(serializer, message: SerializerRequired);
    }

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
    public async Task<T> Clone<T>(T original, CancellationToken cancellationToken)
        where T : notnull
    {
        _ = Guard.Against.Null(original, message: CloneAsyncOriginalRequired);

        IEnumerable<byte> data = await _serializer
            .Serialize(original, cancellationToken)
            .ConfigureAwait(false);

        return await _serializer
            .Deserialize<T>(data, cancellationToken)
            .ConfigureAwait(false);
    }
}