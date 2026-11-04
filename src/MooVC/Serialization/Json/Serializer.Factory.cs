#if NET6_0_OR_GREATER
namespace MooVC.Serialization.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json;
    using Microsoft.Extensions.Configuration;
    using MooVC.Composition;
    using MooVC.Compression;
    using MooVC.Serialization.Composition;
    using Compression = MooVC.Compression.Configuration.Type;
    using Serialization = MooVC.Serialization.Configuration.Type;

    /// <summary>
    /// Represents a serializer that uses JSON as the serialization format.
    /// </summary>
    public partial class Serializer
    {
        /// <summary>
        /// Represents a factory for creating instances of <see cref="Serializer"/>.
        /// </summary>
        /// <param name="compressors">An enumerable collection of instance strategies that provide instances of compressor types and their corresponding compression settings.</param>
        public sealed class Factory(IEnumerable<IInstanceStrategy<ICompressor, Compression>> compressors)
            : Factory<JsonSerializerOptions>(compressors)
        {
            /// <inheritdoc/>
            protected override ISerializer Create(ICompressor compressor, JsonSerializerOptions options)
            {
                return new Serializer(compressor: compressor, options: options);
            }

            /// <inheritdoc/>
            protected override bool IsExpectedType(Serialization type)
            {
                return type == Json;
            }
        }
    }
}
#endif