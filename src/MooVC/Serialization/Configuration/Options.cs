namespace MooVC.Serialization.Configuration
{
    using Fluentify;
    using Valuify;
#if NET6_0_OR_GREATER
    using System.Text.Json;
    using Serializer = MooVC.Serialization.Json.Serializer;
#endif

    /// <summary>
    /// Represents the configuration options for serialization strategies.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Options
    {
        #if NET6_0_OR_GREATER
        /// <summary>
        /// Gets or sets the type of serialization strategy to use.
        /// </summary>
        public Type Type { get; set; } = Serializer.Json;

        /// <summary>
        /// Gets or sets the JSON serializer options.
        /// </summary>
        #if NET9_0_OR_GREATER
        public JsonSerializerOptions Json { get; set; } = JsonSerializerOptions.Web;
        #else
        public JsonSerializerOptions Json { get; set; } = JsonSerializerOptions.Default;
        #endif
        #else
        /// <summary>
        /// Gets or sets the type of serialization strategy to use.
        /// </summary>
        public Type Type { get; set; } = "Newtonsoft.Json";
        #endif
    }
}