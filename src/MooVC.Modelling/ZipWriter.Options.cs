namespace MooVC.Modelling
{
    using System.Diagnostics;
    using System.IO.Compression;

    /// <summary>
    /// Writes generated modelling files to a zip archive.
    /// </summary>
    public partial class ZipWriter
    {
        /// <summary>
        /// Represents configuration options for <see cref="ZipWriter"/>.
        /// </summary>
        [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
        public sealed class Options
        {
            /// <summary>
            /// Gets the configuration section name for these options.
            /// </summary>
            public const string SectionName = nameof(ZipWriter);

            /// <summary>
            /// Gets the default options instance.
            /// </summary>
            public static readonly Options Default = new Options(CompressionLevel.Optimal);

            /// <summary>
            /// Initializes a new instance of the <see cref="Options"/> class.
            /// </summary>
            public Options()
                : this(Default.Compression)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="Options"/> class.
            /// </summary>
            /// <param name="compression">The compression level to use for archive entries.</param>
            public Options(CompressionLevel compression)
            {
                Compression = compression;
            }

            /// <summary>
            /// Gets or sets the compression level to use for archive entries.
            /// </summary>
            public CompressionLevel Compression { get; set; }

            private string GetDebuggerDisplay()
            {
                return $"{nameof(Options)} {{ {nameof(Compression)} = {DebuggerDisplayFormatter.Format(Compression)} }}";
            }
        }
    }
}