namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

internal interface ISerializableInstance
{
    ulong[]? Array { get; }

    int? Integer { get; }

    ISerializableInstance? Object { get; }

    string? String { get; }
}