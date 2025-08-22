namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft.SerializerTests;

internal sealed class SerializableClass
    : ISerializableInstance
{
    public ulong[]? Array { get; set; }

    public int? Integer { get; set; }

    public ISerializableInstance? Object { get; set; }

    public string? String { get; set; }
}