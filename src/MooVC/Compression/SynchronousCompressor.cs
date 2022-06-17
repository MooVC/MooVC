namespace MooVC.Compression;

using System.IO;
using System.Threading;
using System.Threading.Tasks;

public abstract class SynchronousCompressor
    : Compressor
{
    public override Task<Stream> CompressAsync(
        Stream source,
        CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformCompress(source));
    }

    public override Task<Stream> DecompressAsync(
        Stream source,
        CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformDecompress(source));
    }

    protected abstract Stream PerformCompress(Stream source);

    protected abstract Stream PerformDecompress(Stream source);
}