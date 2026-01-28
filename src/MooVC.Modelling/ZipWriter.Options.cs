namespace MooVC.Modelling;

using System.IO.Compression;

internal partial class ZipWriter
{
    public sealed record Options(CompressionLevel Compression)
    {
        public static readonly Options Default = new(CompressionLevel.Optimal);
    }
}