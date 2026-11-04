namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft
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
    /// Provides a factory for creating instances of <see cref="Serializer" />.
    /// </summary>
    public partial class Serializer
    {
        /// <summary>
        /// Defines a factory for creating instances of <see cref="Serializer" />.
        /// </summary>
        public sealed class Factory
            : Factory<JsonSerializerSettings>
        {
            /// <summary>
            /// Initializes a new instance of the Factory class with a collection of instance strategies for
            /// compressors.
            /// </summary>
            /// <param name="compressors">An enumerable collection of instance strategies that provide instances of compressor types and their
            /// corresponding compression algorithms.</param>
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
                return type == NewtonsoftBson;
            }
        }
    }
}