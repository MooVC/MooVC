#if NET6_0_OR_GREATER
namespace MooVC.Serialization.Json;

using System.Text.Json;
using static MooVC.Serialization.Json.Serializer_Resources;
using Base = MooVC.Serialization.Serializer;

/// <summary>
/// Provides an implementation of type <see cref="ISerializer"/> that utilizes the <see cref="JsonSerializer"/>.
/// </summary>
public sealed class Serializer
    : Base
{
    private readonly JsonSerializerOptions _options;

    /// <summary>
    /// Constructs a new instance of <see cref="Serializer"/>.
    /// </summary>
    /// <param name="options">The serialization options to use with <see cref="JsonSerializer"/>.</param>
    public Serializer(JsonSerializerOptions? options = default)
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
}
#endif