namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests;

internal sealed class SerializableClass
    : ISerializableInstance
{
    public IEnumerable<ulong>? Array { get; init; }

    public int? Integer { get; init; }

    public ISerializableInstance? Object { get; init; }

    public string? String { get; init; }
}