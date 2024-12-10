#if NET5_0_OR_GREATER
namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

[MessagePackObject(keyAsPropertyName: true)]
public sealed record SerializableRecord(IEnumerable<ulong>? Array, int? Integer, ISerializableInstance? Object, string? String)
    : ISerializableInstance;
#endif