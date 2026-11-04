#if NET6_0_OR_GREATER
#nullable enable
namespace MooVC.Serialization.Json
{
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Compression;
    using static MooVC.Serialization.Json.Serializer_Resources;
    using Base = MooVC.Serialization.Serializer;
    using Type = MooVC.Serialization.Configuration.Type;

    /// <summary>
    /// Provides an implementation of type <see cref="ISerializer"/> that utilizes the <see cref="JsonSerializer"/>.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="JsonSerializerOptions.Default" /> on .NET 7+ and web defaults on earlier target frameworks when options are not provided.
    /// </remarks>
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public sealed partial class Serializer
        : Base
    {
        /// <summary>
        /// Gets the type identifier for the JSON serializer.
        /// </summary>
        public static readonly Type Json = "Json";

        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Constructs a new instance of <see cref="Serializer"/>.
        /// </summary>
        /// <param name="options">The serialization options to use with <see cref="JsonSerializer"/>.</param>
        public Serializer(JsonSerializerOptions? options = default)
            : this(compressor: default, options: options)
        {
        }

        /// <summary>
        /// Constructs a new instance of <see cref="Serializer"/> with optional compression.
        /// </summary>
        /// <param name="compressor">The compressor to use when serializing and deserializing.</param>
        /// <param name="options">The serialization options to use with <see cref="JsonSerializer"/>.</param>
        public Serializer(ICompressor? compressor, JsonSerializerOptions? options)
            : base(compressor: compressor)
        {
            #if NET7_0_OR_GREATER
            _options = options ?? JsonSerializerOptions.Default;
            #else
            _options = options ?? new JsonSerializerOptions(JsonSerializerDefaults.Web);
            #endif
        }

        /// <inheritdoc/>
        protected override async Task<T> PerformDeserialize<T>(Stream source, CancellationToken cancellationToken)
        {
            T? instance = await JsonSerializer
                .DeserializeAsync<T>(source, options: _options, cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return instance ?? throw new JsonException(PerformDeserializeFailed.Format(typeof(T)));
        }

        /// <inheritdoc/>
        protected override Task PerformSerialize<T>(T instance, Stream target, CancellationToken cancellationToken)
        {
            return JsonSerializer.SerializeAsync(target, instance, options: _options, cancellationToken: cancellationToken);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Serializer)} {{ {GetHashCode()} }}";
        }
    }
}
#endif