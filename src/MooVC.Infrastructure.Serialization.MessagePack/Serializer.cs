namespace MooVC.Infrastructure.Serialization.MessagePack;

using global::MessagePack;
using MooVC.Compression;
using static System.String;
using static MooVC.Infrastructure.Serialization.MessagePack.Resources;
using Base = MooVC.Serialization.Serializer;

/// <summary>
/// Provides MessagePack serialization.
/// </summary>
/// <remarks>
/// Delegates serialization to <see cref="MessagePackSerializer" /> using configured <see cref="MessagePackSerializerOptions" /> and optional stream compression.
/// </remarks>
public sealed class Serializer
    : Base
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Serializer"/> class.
    /// </summary>
    /// <param name="compressor">The optional stream compressor.</param>
    /// <param name="options">The MessagePack serializer options.</param>
    public Serializer(ICompressor? compressor = default, MessagePackSerializerOptions? options = default)
        : base(compressor: compressor)
    {
        Options = options ?? MessagePackSerializerOptions.Standard;
    }

    /// <summary>
    /// Gets the MessagePack serializer options used for serialization operations.
    /// </summary>
    public MessagePackSerializerOptions Options { get; }

    protected override async Task<T> PerformDeserialize<T>(Stream source, CancellationToken cancellationToken)
    {
        return await MessagePackSerializer
            .DeserializeAsync<T>(source, options: Options, cancellationToken: cancellationToken)
            .ConfigureAwait(false)
            ?? throw new MessagePackSerializationException(Format(SerializerPerformDeserializeAsyncFailure, typeof(T)));
    }

    protected override Task PerformSerialize<T>(T instance, Stream target, CancellationToken cancellationToken)
    {
        return MessagePackSerializer.SerializeAsync(
            target,
            instance,
            options: Options,
            cancellationToken: cancellationToken);
    }
}