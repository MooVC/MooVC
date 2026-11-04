namespace MooVC.Compression.Configuration
{
    using Fluentify;
    using Valuify;

    /// <summary>
    /// Represents the configuration options for compression strategies.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Options
    {
        /// <summary>
        /// Gets or sets the type of compression strategy to use.
        /// </summary>
        public Type Type { get; set; } = "None";

        /// <summary>
        /// Gets or sets the options for the Brotli compression strategy.
        /// </summary>
        public StreamCompressor.Options Brotli { get; set; } = new StreamCompressor.Options();

        /// <summary>
        /// Gets or sets the options for the Deflate compression strategy.
        /// </summary>
        public StreamCompressor.Options Deflate { get; set; } = new StreamCompressor.Options();

        /// <summary>
        /// Gets or sets the options for the GZip compression strategy.
        /// </summary>
        public StreamCompressor.Options GZip { get; set; } = new StreamCompressor.Options();
    }
}