namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft.SerializerTests;

internal interface ISerializableInstance
{
    ulong[]? Array { get; }

    int? Integer { get; }

    ISerializableInstance? Object { get; }

    string? String { get; }
}