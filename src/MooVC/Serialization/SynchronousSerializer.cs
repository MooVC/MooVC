namespace MooVC.Serialization;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Compression;

/// <summary>
/// Faciliates implementation of a synchronous implementation of the <see cref="ISerializer"/> contract for serializing and deserializing objects.
/// </summary>
public abstract class SynchronousSerializer
    : Serializer
{
    /// <summary>
    /// Facilitates the Initialization of new instance based on the <see cref="SynchronousSerializer"/> class.
    /// </summary>
    /// <param name="compressor">
    /// The optional <see cref="ICompressor"/> to use to compress/decompress the serialize/deserialized data.
    /// If no instance is provided, the streams will not be compressed/decompressed.
    /// </param>
    protected SynchronousSerializer(ICompressor? compressor = default)
        : base(compressor: compressor)
    {
    }

    /// <summary>
    /// Asynchronously deserializes of the result that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous deserialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    protected override Task<T> PerformDeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformDeserialize<T>(source));
    }

    /// <summary>
    /// Asynchronously serializes of the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous serialization operation.</returns>
    protected override Task PerformSerializeAsync<T>(T instance, Stream target, CancellationToken? cancellationToken = default)
    {
        PerformSerialize(instance, target);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Facilitates synchronous deserialization of the result that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <returns>The instance deserialized from the stream that represented the object.</returns>
    protected abstract T PerformDeserialize<T>(Stream source)
        where T : notnull;

    /// <summary>
    /// Facilitates synchronous serialization of the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    protected abstract void PerformSerialize<T>(T instance, Stream target)
        where T : notnull;
}