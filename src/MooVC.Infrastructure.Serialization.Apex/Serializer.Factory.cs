namespace MooVC.Infrastructure.Serialization.Apex;

using System.Diagnostics.CodeAnalysis;
using global::Apex.Serialization;
using Microsoft.Extensions.Configuration;
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
    /// <param name="compressors">An enumerable collection of instance strategies that provide instances of compressor types and their corresponding compression settings.</param>
    public sealed class Factory(IEnumerable<IInstanceStrategy<ICompressor, Compression>> compressors)
        : Factory<Settings>(compressors)
    {
        /// <inheritdoc/>
        protected override ISerializer Create(ICompressor compressor, Settings options)
        {
            return new Serializer(compressor: compressor, settings: options);
        }

        /// <inheritdoc/>
        protected override bool IsExpectedType(Serialization type)
        {
            return type == Apex;
        }
    }
}