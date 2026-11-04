namespace MooVC.Serialization.Composition
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Configuration;
    using MooVC.Composition;
    using MooVC.Compression;
    using MooVC.Serialization.Configuration;
    using static MooVC.Serialization.Composition.Factory_Resources;
    using Compression = MooVC.Compression.Configuration.Type;
    using CompressionOptions = MooVC.Compression.Configuration.Options;
    using Serialization = MooVC.Serialization.Configuration.Type;

    /// <summary>
    /// Represents a factory that creates instances of <see cref="Serializer"/> based on a given configuration and type.
    /// </summary>
    public abstract class Factory<TOptions>
        : IInstanceStrategy<ISerializer, Serialization>
        where TOptions : class
    {
        private readonly IEnumerable<IInstanceStrategy<ICompressor, Compression>> _compressors;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory{TOptions}"/> class with the specified compressors.
        /// </summary>
        /// <param name="compressors">The compressors to use.</param>
        protected Factory(IEnumerable<IInstanceStrategy<ICompressor, Compression>> compressors)
        {
            _compressors = Guard.Against.Null(compressors, message: CompressorsRequired);
        }

        /// <summary>
        /// Attempts to create an instance of <see cref="ISerializer"/> based on the provided configuration and type.
        /// </summary>
        /// <param name="configuration">The configuration section.</param>
        /// <param name="type">The type of serializer to create.</param>
        /// <param name="instance">When this method returns, contains the created instance or null if the creation failed.</param>
        /// <returns>true if the instance was created successfully; otherwise, false.</returns>
        public bool TryCreate(
            IConfigurationSection configuration,
            Serialization type,
            #if NET6_0_OR_GREATER
            [MaybeNullWhen(false)]
            #endif
            out ISerializer instance)
        {
            if (IsExpectedType(type))
            {
                _ = Guard.Against.Null(configuration, nameof(configuration));

                IConfigurationSection compression = configuration.GetSection(nameof(Serializer<TOptions>.Compression));
                Compression compressionType = compression.GetValue(nameof(CompressionOptions.Type), new CompressionOptions().Type);
                TOptions settings = configuration.GetSection(nameof(Serializer<TOptions>.Settings)).Get<TOptions>();
                compression = compression.GetSection(compressionType.ToString());

                _ = _compressors.TryCreate(compression, compressionType, out ICompressor compressor);
                instance = Create(compressor, settings);

                return true;
            }

            instance = default;

            return false;
        }

        /// <summary>
        /// Creates an instance of <see cref="ISerializer"/> using the specified compressor and options.
        /// </summary>
        /// <param name="compressor">The compressor to use.</param>
        /// <param name="options">The options for the serializer.</param>
        /// <returns>The created serializer instance.</returns>
        protected abstract ISerializer Create(ICompressor compressor, TOptions options);

        /// <summary>
        /// Determines whether the specified type is the expected type for this factory.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>true if the type is expected; otherwise, false.</returns>
        protected abstract bool IsExpectedType(Serialization type);
    }
}