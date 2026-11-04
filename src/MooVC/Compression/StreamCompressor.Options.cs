namespace MooVC.Compression
{
    using System.IO.Compression;
    using Fluentify;
    using Valuify;

    /// <summary>
    /// Represents a compressor that can compress and decompress streams of data.
    /// </summary>
    public partial class StreamCompressor
    {
        /// <summary>
        /// Represents the options for configuring a <see cref="StreamCompressor" /> instance.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// The default buffer size for stream copy operations.
            /// </summary>
            public const int DefaultBufferSize = 81920;

            /// <summary>
            /// Gets or sets the buffer size to use when copying from one stream to another.
            /// </summary>
            public int BufferSize { get; set; } = DefaultBufferSize;

            /// <summary>
            /// Gets or sets the <see cref="CompressionLevel" /> to use for compression and decompression.
            /// </summary>
            public CompressionLevel Level { get; set; } = CompressionLevel.Optimal;
        }
    }
}