namespace MooVC.Modelling;

using System.IO.Compression;

public partial class ZipWriter
{
    /// <summary>
    /// Represents configuration options for <see cref="ZipWriter"/>.
    /// </summary>
    public sealed record Options(CompressionLevel Compression)
    {
        /// <summary>
        /// Gets the configuration section name for these options.
        /// </summary>
        public const string SectionName = nameof(ZipWriter);

        /// <summary>
        /// Gets the default options instance.
        /// </summary>
        public static readonly Options Default = new(CompressionLevel.Optimal);

        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> record.
        /// </summary>
        public Options()
            : this(Default.Compression)
        {
        }
    }
}