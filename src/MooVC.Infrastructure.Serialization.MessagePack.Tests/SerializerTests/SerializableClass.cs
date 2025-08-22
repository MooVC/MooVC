namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

[MessagePackObject(keyAsPropertyName: true)]
public sealed class SerializableClass
    : ISerializableInstance
{
    public ulong[]? Array { get; set; }

    public int? Integer { get; set; }

    public ISerializableInstance? Object { get; set; }

    public string? String { get; set; }
}