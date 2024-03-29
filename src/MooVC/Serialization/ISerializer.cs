﻿namespace MooVC.Serialization;

using System.IO;

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
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous serialization operation.
    /// The result of the task is a sequence of bytes representing the serialized object.
    /// </returns>
    Task<IEnumerable<byte>> Serialize<T>(T instance, CancellationToken cancellationToken)
        where T : notnull;

    /// <summary>
    /// Asynchronously serializes the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous serialization operation.</returns>
    Task Serialize<T>(T instance, Stream target, CancellationToken cancellationToken)
        where T : notnull;

    /// <summary>
    /// Asynchronously deserializes a sequence of bytes that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="data">The sequence of bytes to deserialize.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous serialization operation.
    /// The result of the task is the instance deserialized from the sequence of bytes that represented the object.
    /// </returns>
    Task<T> Deserialize<T>(IEnumerable<byte> data, CancellationToken cancellationToken)
        where T : notnull;

    /// <summary>
    /// Asynchronously deserializes a stream that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous serialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    Task<T> Deserialize<T>(Stream source, CancellationToken cancellationToken)
        where T : notnull;
}