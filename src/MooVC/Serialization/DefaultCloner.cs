namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using static MooVC.Ensure;
using static MooVC.Serialization.Resources;

/// <summary>
/// Defines a default implementation of the <see cref="ICloner"/> interface, supporting object cloning via <see cref="ISerializer"/>.
/// </summary>
public sealed class DefaultCloner
    : ICloner
{
    private readonly ISerializer serializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultCloner"/> class with the specified <see cref="ISerializer"/>.
    /// </summary>
    /// <param name="serializer">The serializer to use for cloning objects.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="serializer"/> is <see langword="null" />.</exception>
    public DefaultCloner(ISerializer serializer)
    {
        this.serializer = IsNotNull(serializer, argumentName: nameof(serializer), message: DefaultClonerSerializerRequired);
    }

    /// <summary>
    /// Asynchronously clones the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to clone.</typeparam>
    /// <param name="original">The original object to clone.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous clone operation.
    /// The task result contains the cloned object.
    /// </returns>
    public async Task<T> CloneAsync<T>(T original, CancellationToken cancellationToken)
        where T : notnull
    {
        _ = Guard.Against.Null(original, nameof(original), message: DefaultClonerCloneAsyncOriginalRequired);

        IEnumerable<byte> data = await serializer
            .SerializeAsync(original, cancellationToken)
            .ConfigureAwait(false);

        return await serializer
            .DeserializeAsync<T>(data, cancellationToken)
            .ConfigureAwait(false);
    }
}