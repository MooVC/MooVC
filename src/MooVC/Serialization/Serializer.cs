namespace MooVC.Serialization;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Compression;

public abstract class Serializer
    : ISerializer
{
    private readonly ICompressor? compressor;

    protected Serializer(ICompressor? compressor = default)
    {
        this.compressor = compressor;
    }

    public async Task<T> DeserializeAsync<T>(IEnumerable<byte> data, CancellationToken? cancellationToken = default)
        where T : notnull
    {
        using var source = new MemoryStream(data.ToArray());

        return await DeserializeAsync<T>(source, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<T> DeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
        where T : notnull
    {
        using var decompressed = new MemoryStream();

        await DecompressAsync(source, decompressed, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        decompressed.Position = 0;

        return await PerformDeserializeAsync<T>(decompressed, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<IEnumerable<byte>> SerializeAsync<T>(
        T instance,
        CancellationToken? cancellationToken = default)
        where T : notnull
    {
        using var target = new MemoryStream();

        await SerializeAsync(instance, target, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return target.ToArray();
    }

    public async Task SerializeAsync<T>(
        T instance,
        Stream target,
        CancellationToken? cancellationToken = default)
        where T : notnull
    {
        using var serialized = new MemoryStream();

        await PerformSerializeAsync(instance, serialized, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        serialized.Position = 0;

        await CompressAsync(serialized, target, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    protected async Task CompressAsync(Stream source, Stream target, CancellationToken? cancellationToken = default)
    {
        cancellationToken = cancellationToken.GetValueOrDefault();

        if (compressor is { })
        {
            using Stream compressed = await compressor
                .CompressAsync(source, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            compressed.Position = 0;

            await compressed
                .CopyToAsync(target, cancellationToken.Value)
                .ConfigureAwait(false);
        }
        else
        {
            await source
                .CopyToAsync(target, cancellationToken.Value)
                .ConfigureAwait(false);
        }
    }

    protected async Task DecompressAsync(Stream source, Stream target, CancellationToken? cancellationToken = default)
    {
        cancellationToken = cancellationToken.GetValueOrDefault();

        if (compressor is { })
        {
            using Stream decompressed = await compressor
                .DecompressAsync(source, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            decompressed.Position = 0;

            await decompressed
                .CopyToAsync(target, cancellationToken.Value)
                .ConfigureAwait(false);
        }
        else
        {
            await source
                .CopyToAsync(target, cancellationToken.Value)
                .ConfigureAwait(false);
        }
    }

    protected abstract Task<T> PerformDeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
        where T : notnull;

    protected abstract Task PerformSerializeAsync<T>(T instance, Stream target, CancellationToken? cancellationToken = default)
        where T : notnull;
}