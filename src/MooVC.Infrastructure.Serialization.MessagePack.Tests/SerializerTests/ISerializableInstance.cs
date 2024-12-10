namespace MooVC.Infrastructure.Serialization.MessagePack.SerializerTests;

using global::MessagePack;

[Union(0, typeof(SerializableClass))]
#if NET5_0_OR_GREATER
[Union(1, typeof(SerializableRecord))]
#endif
public interface ISerializableInstance
{
    IEnumerable<ulong>? Array { get; }

    int? Integer { get; }

    ISerializableInstance? Object { get; }

    string? String { get; }
}