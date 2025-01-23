namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

internal sealed class SerializableClass
    : ISerializableInstance
{
    public IEnumerable<ulong>? Array { get; set; }

    public int? Integer { get; set; }

    public ISerializableInstance? Object { get; set; }

    public string? String { get; set; }
}