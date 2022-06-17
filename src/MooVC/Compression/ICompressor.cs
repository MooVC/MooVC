namespace MooVC.Compression;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public interface ICompressor
{
    Task<IEnumerable<byte>> CompressAsync(
        IEnumerable<byte> data,
        CancellationToken? cancellationToken = default);

    Task<Stream> CompressAsync(
        Stream source,
        CancellationToken? cancellationToken = default);

    Task<IEnumerable<byte>> DecompressAsync(
        IEnumerable<byte> data,
        CancellationToken? cancellationToken = default);

    Task<Stream> DecompressAsync(
        Stream source,
        CancellationToken? cancellationToken = default);
}