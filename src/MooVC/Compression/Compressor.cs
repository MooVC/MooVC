namespace MooVC.Compression;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MooVC.IO;

public abstract class Compressor
    : ICompressor
{
    public async Task<IEnumerable<byte>> CompressAsync(IEnumerable<byte> data, CancellationToken? cancellationToken = default)
    {
        using var source = new MemoryStream(data.ToArray());

        using Stream compressed = await CompressAsync(source, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return compressed.GetBytes();
    }

    public abstract Task<Stream> CompressAsync(Stream source, CancellationToken? cancellationToken = default);

    public async Task<IEnumerable<byte>> DecompressAsync(IEnumerable<byte> data, CancellationToken? cancellationToken = default)
    {
        using var source = new MemoryStream(data.ToArray());

        using Stream decompressed = await DecompressAsync(source, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return decompressed.GetBytes();
    }

    public abstract Task<Stream> DecompressAsync(Stream source, CancellationToken? cancellationToken = default);
}