namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

internal interface ISerializableInstance
{
    IEnumerable<ulong>? Array { get; }

    int? Integer { get; }

    ISerializableInstance? Object { get; }

    string? String { get; }
}