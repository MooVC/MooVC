namespace MooVC.Serialization;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using MooVC.Compression;
using static MooVC.Serialization.Serializer_Resources;

/// <summary>
/// Provides a default implementation of the <see cref="ISerializer" /> contract for serializing and deserializing objects.
/// </summary>
public abstract class Serializer
    : ISerializer
{
    /// <summary>
    /// The default buffer size for stream copy operations.
    /// </summary>
    public const int DefaultBufferSize = 81920;

    private readonly int bufferSize;
    private readonly ICompressor? compressor;

    /// <summary>
    /// Facilitates the Initialization of new instance based on the <see cref="Serializer" /> class.
    /// </summary>
    /// <param name="bufferSize">The buffer size to use when copying from one stream to another.</param>
    /// <param name="compressor">
    /// The optional <see cref="ICompressor" /> to use to compress/decompress the serialize/deserialized data.
    /// If no instance is provided, the streams will not be compressed/decompressed.
    /// </param>
    protected Serializer(int bufferSize = DefaultBufferSize, ICompressor? compressor = default)
    {
        this.bufferSize = Guard.Against.NegativeOrZero(bufferSize, parameterName: nameof(bufferSize), message: BufferSizeRequired);
        this.compressor = compressor;
    }

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
    public async Task<T> DeserializeAsync<T>(IEnumerable<byte> data, CancellationToken cancellationToken)
        where T : notnull
    {
        _ = Guard.Against.Null(data, parameterName: nameof(data), DeserializeAsyncDataRequired);

        using var source = new MemoryStream(data.ToArray());

        return await DeserializeAsync<T>(source, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously decompresses a stream (if provided) and deserializes the result that represent an object of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to deserialize.</typeparam>
    /// <param name="source">The stream from which the object is to be deserialized.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous serialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    public async Task<T> DeserializeAsync<T>(Stream source, CancellationToken cancellationToken)
        where T : notnull
    {
        _ = Guard.Against.Null(source, parameterName: nameof(source), DeserializeAsyncSourceRequired);

        using var decompressed = new MemoryStream();

        await DecompressAsync(source, decompressed, cancellationToken)
            .ConfigureAwait(false);

        decompressed.Position = 0;

        return await PerformDeserializeAsync<T>(decompressed, cancellationToken)
            .ConfigureAwait(false);
    }

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
    public async Task<IEnumerable<byte>> SerializeAsync<T>(T instance, CancellationToken cancellationToken)
        where T : notnull
    {
        using var target = new MemoryStream();

        await SerializeAsync(instance, target, cancellationToken)
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
    /// <returns>A <see cref="Task" /> that represents the asynchronous serialization operation.</returns>
    public async Task SerializeAsync<T>(T instance, Stream target, CancellationToken cancellationToken)
        where T : notnull
    {
        _ = Guard.Against.Null(target, parameterName: nameof(target), SerializeAsyncTargetRequired);

        using var serialized = new MemoryStream();

        await PerformSerializeAsync(instance, serialized, cancellationToken)
            .ConfigureAwait(false);

        serialized.Position = 0;

        await CompressAsync(serialized, target, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asynchronously compresses the contents of the <paramref name="source" /> stream and writes the compressed data to the
    /// <paramref name="target" /> stream if a compressor has been provided on construction, otherwise the contents of the <paramref name="source" />
    /// stream are simlply copied to the <paramref name="target" /> stream.
    /// </summary>
    /// <param name="source">The stream containing the data to be compressed/copied.</param>
    /// <param name="target">The stream to which the data will be written.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous serialization operation.</returns>
    protected async Task CompressAsync(Stream source, Stream target, CancellationToken cancellationToken)
    {
        if (compressor is null)
        {
            await source
                .CopyToAsync(target, bufferSize, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            using Stream compressed = await compressor
                .CompressAsync(source, cancellationToken)
                .ConfigureAwait(false);

            compressed.Position = 0;

            await compressed
                .CopyToAsync(target, bufferSize, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Asynchronously decompresses the contents of the <paramref name="source" /> stream and writes the decompressed data to the
    /// <paramref name="target" /> stream if a compressor has been provided on construction, otherwise the contents of the <paramref name="source" />
    /// stream are simlply copied to the <paramref name="target" /> stream.
    /// </summary>
    /// <param name="source">The stream containing the data to be decompressed/copied.</param>
    /// <param name="target">The stream to which the data will be written.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    protected async Task DecompressAsync(Stream source, Stream target, CancellationToken cancellationToken)
    {
        if (compressor is null)
        {
            await source
                .CopyToAsync(target, bufferSize, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            using Stream decompressed = await compressor
                .DecompressAsync(source, cancellationToken)
                .ConfigureAwait(false);

            decompressed.Position = 0;

            await decompressed
                .CopyToAsync(target, bufferSize, cancellationToken)
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
    /// A <see cref="Task{TResult}" /> that represents the asynchronous deserialization operation.
    /// The result of the task is the instance deserialized from the stream that represented the object.
    /// </returns>
    protected abstract Task<T> PerformDeserializeAsync<T>(Stream source, CancellationToken cancellationToken)
        where T : notnull;

    /// <summary>
    /// Facilitates asynchronously implementation of the serialization of the specified object to the specified stream.
    /// </summary>
    /// <typeparam name="T">The type of the object to serialize.</typeparam>
    /// <param name="instance">The object to serialize.</param>
    /// <param name="target">The target stream to which to serialize the object.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous serialization operation.</returns>
    protected abstract Task PerformSerializeAsync<T>(T instance, Stream target, CancellationToken cancellationToken)
        where T : notnull;
}