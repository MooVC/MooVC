﻿namespace MooVC.Serialization;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Compression;

/// <summary>
/// Provides a default implementation of the <see cref="ISerializer"/> contract for serializing and deserializing objects.
/// </summary>
public abstract class Serializer
    : ISerializer
{
    private readonly ICompressor? compressor;

    /// <summary>
    /// Facilitates the Initialization of new instance based on the <see cref="Serializer"/> class.
    /// </summary>
    /// <param name="compressor">
    /// The optional <see cref="ICompressor"/> to use to compress/decompress the serialize/deserialized data.
    /// If no instance is provided, the streams will not be compressed/decompressed.
    /// </param>
    protected Serializer(ICompressor? compressor = default)
    {
        this.compressor = compressor;
    }

    /// <summary>
    /// Asynchronously deserializes a sequence of bytes that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="data">The sequence of bytes to deserialize.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation.
    /// The result of the task is the instance deserialized from the sequence of bytes that represented the object.
    /// </returns>
    public async Task<T> DeserializeAsync<T>(IEnumerable<byte> data, CancellationToken cancellationToken = default)
        where T : notnull
    {
        using var source = new MemoryStream(data.ToArray());

        return await DeserializeAsync<T>(source, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously decompresses a stream (if provided) and deserializes the result that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    public async Task<T> DeserializeAsync<T>(Stream source, CancellationToken cancellationToken = default)
        where T : notnull
    {
        using var decompressed = new MemoryStream();

        await DecompressAsync(source, decompressed, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        decompressed.Position = 0;

        return await PerformDeserializeAsync<T>(decompressed, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously serializes the specified object.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous serialization operation.
    /// The result of the task is a sequence of bytes representing the serialized object.
    /// </returns>
    public async Task<IEnumerable<byte>> SerializeAsync<T>(T instance, CancellationToken cancellationToken = default)
        where T : notnull
    {
        using var target = new MemoryStream();

        await SerializeAsync(instance, target, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return target.ToArray();
    }

    /// <summary>
    /// Asynchronously serializes the specified object to the specified stream and compresses the result (if provided).
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous serialization operation.</returns>
    public async Task SerializeAsync<T>(T instance, Stream target, CancellationToken cancellationToken = default)
        where T : notnull
    {
        using var serialized = new MemoryStream();

        await PerformSerializeAsync(instance, serialized, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        serialized.Position = 0;

        await CompressAsync(serialized, target, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously compresses the contents of the <paramref name="source"/> stream and writes the compressed data to the
    /// <paramref name="target"/> stream if a compressor has been provided on construction, otherwise the contents of the <paramref name="source"/>
    /// stream are simlply copied to the <paramref name="target"/> stream.
    /// </summary>
    /// <param name="source">The stream containing the data to be compressed/copied.</param>
    /// <param name="target">The stream to which the data will be written.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous serialization operation.</returns>
    protected async Task CompressAsync(Stream source, Stream target, CancellationToken cancellationToken = default)
    {
        if (compressor is { })
        {
            using Stream compressed = await compressor
                .CompressAsync(source, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            compressed.Position = 0;

            await compressed
                .CopyToAsync(target, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            await source
                .CopyToAsync(target, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Asynchronously decompresses the contents of the <paramref name="source"/> stream and writes the decompressed data to the
    /// <paramref name="target"/> stream if a compressor has been provided on construction, otherwise the contents of the <paramref name="source"/>
    /// stream are simlply copied to the <paramref name="target"/> stream.
    /// </summary>
    /// <param name="source">The stream containing the data to be decompressed/copied.</param>
    /// <param name="target">The stream to which the data will be written.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected async Task DecompressAsync(Stream source, Stream target, CancellationToken cancellationToken = default)
    {
        if (compressor is { })
        {
            using Stream decompressed = await compressor
                .DecompressAsync(source, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            decompressed.Position = 0;

            await decompressed
                .CopyToAsync(target, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            await source
                .CopyToAsync(target, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Facilitates asynchronously implementation of the deserialization of the result that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous deserialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    protected abstract Task<T> PerformDeserializeAsync<T>(Stream source, CancellationToken cancellationToken = default)
        where T : notnull;

    /// <summary>
    /// Facilitates asynchronously implementation of the serialization of the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous serialization operation.</returns>
    protected abstract Task PerformSerializeAsync<T>(T instance, Stream target, CancellationToken cancellationToken = default)
        where T : notnull;
}