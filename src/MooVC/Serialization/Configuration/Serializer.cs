namespace MooVC.Serialization.Configuration
{
    using Fluentify;
    using Valuify;
    using Compression = MooVC.Compression.Configuration.Options;

    /// <summary>
    /// Represents the configuration options for a serialization strategy.
    /// </summary>
    /// <typeparam name="T">The type of the serialization settings.</typeparam>
    [Fluentify]
    [Valuify]
    public sealed partial class Serializer<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets the options for the compression strategy to use with the serialization strategy.
        /// </summary>
        public Compression Compression { get; set; } = new Compression();

        /// <summary>
        /// Gets or sets the settings for the serialization strategy.
        /// </summary>
        public T Settings { get; set; }
    }
}