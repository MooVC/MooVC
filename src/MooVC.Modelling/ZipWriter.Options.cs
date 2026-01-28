namespace MooVC.Modelling;

using System.IO.Compression;

public partial class ZipWriter
{
    public sealed record Options(CompressionLevel Compression)
    {
        public const string SectionName = nameof(ZipWriter);

        public static readonly Options Default = new(CompressionLevel.Optimal);

        public Options()
            : this(Default.Compression)
        {
        }
    }
}