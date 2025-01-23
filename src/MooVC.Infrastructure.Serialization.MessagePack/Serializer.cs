namespace MooVC.Infrastructure.Serialization.MessagePack;

using global::MessagePack;
using MooVC.Compression;
using static System.String;
using static MooVC.Infrastructure.Serialization.MessagePack.Resources;
using Base = MooVC.Serialization.Serializer;

public sealed class Serializer
    : Base
{
    public Serializer(ICompressor? compressor = default, MessagePackSerializerOptions? options = default)
        : base(compressor: compressor)
    {
        Options = options ?? MessagePackSerializerOptions.Standard;
    }

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