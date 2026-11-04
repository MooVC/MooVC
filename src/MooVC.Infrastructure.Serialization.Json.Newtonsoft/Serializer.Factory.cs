namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft
{
    using System.Collections.Generic;
    using global::Newtonsoft.Json;
    using MooVC.Composition;
    using MooVC.Compression;
    using MooVC.Serialization;
    using MooVC.Serialization.Composition;
    using Compression = MooVC.Compression.Configuration.Type;
    using Serialization = MooVC.Serialization.Configuration.Type;

    /// <summary>
    /// Represents a factory for creating instances of <see cref="Serializer"/>.
    /// </summary>
    public partial class Serializer
    {
        /// <summary>
        /// Represents a factory for creating instances of <see cref="Serializer"/>.
        /// </summary>
        public sealed class Factory
            : Factory<JsonSerializerSettings>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Factory"/> class.
            /// </summary>
            /// <param name="compressors">
            /// An enumerable collection of instance strategies that provide instances of compressor types and their
            /// corresponding compression settings.
            /// </param>
            public Factory(IEnumerable<IInstanceStrategy<ICompressor, Compression>> compressors)
                : base(compressors)
            {
            }

            /// <inheritdoc/>
            protected override ISerializer Create(ICompressor compressor, JsonSerializerSettings options)
            {
                return new Serializer(compressor: compressor, settings: options);
            }

            /// <inheritdoc/>
            protected override bool IsExpectedType(Serialization type)
            {
                return type == NewtonsoftJson;
            }
        }
    }
}