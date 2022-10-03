namespace MooVC.Compression;

using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Compression.Resources;
using static MooVC.Ensure;

public sealed class DeflateCompressor
    : Compressor
{
    private readonly CompressionLevel level;

    public DeflateCompressor(CompressionLevel level = CompressionLevel.SmallestSize)
    {
        this.level = IsDefined(level, message: DeflateCompressorLevelRequired);
    }

    public override async Task<Stream> CompressAsync(Stream source, CancellationToken? cancellationToken = default)
    {
        var result = new MemoryStream();

        using var compressor = new DeflateStream(result, CompressionLevel.SmallestSize, true);

        await source
            .CopyToAsync(compressor, cancellationToken.GetValueOrDefault())
            .ConfigureAwait(false);

        return result;
    }

    public override async Task<Stream> DecompressAsync(Stream source, CancellationToken? cancellationToken = null)
    {
        var result = new MemoryStream();

        using var decompressor = new DeflateStream(source, CompressionMode.Decompress, true);

        await decompressor
            .CopyToAsync(result, cancellationToken.GetValueOrDefault())
            .ConfigureAwait(false);

        return result;
    }
}