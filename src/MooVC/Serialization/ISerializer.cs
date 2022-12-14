namespace MooVC.Serialization;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Defines a contract for serializing and deserializing objects.
/// </summary>
public interface ISerializer
{
    /// <summary>
    /// Asynchronously serializes the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation. The result of the task is a sequence
    /// of bytes representing the serialized object.
    /// </returns>
    Task<IEnumerable<byte>> SerializeAsync<T>(T instance, CancellationToken? cancellationToken = default)
        where T : notnull;

    /// <summary>
    /// Asynchronously serializes the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
    /// </param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous serialization operation.</returns>
    Task SerializeAsync<T>(T instance, Stream target, CancellationToken? cancellationToken = default)
        where T : notnull;

    /// <summary>
    /// Asynchronously deserializes a sequence of bytes that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="data">The sequence of bytes to deserialize.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation. The result of the task is the
    /// instance deserialized from the sequence of bytes that represented the object.
    /// </returns>
    Task<T> DeserializeAsync<T>(IEnumerable<byte> data, CancellationToken? cancellationToken = default)
        where T : notnull;

    /// <summary>
    /// Asynchronously deserializes a stream that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken" /> that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation. The result of the task is the instance
    /// deserialized from the stream that represented the object.
    /// </returns>
    Task<T> DeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
        where T : notnull;
}