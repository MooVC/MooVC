namespace MooVC.Modelling;

using System.IO.Compression;

public partial class ZipWriter
{
    public sealed record Options(CompressionLevel Compression)
    {
        public static readonly Options Default = new(CompressionLevel.Optimal);
    }
}