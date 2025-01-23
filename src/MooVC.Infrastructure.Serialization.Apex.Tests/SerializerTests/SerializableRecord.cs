namespace MooVC.Infrastructure.Serialization.Apex.SerializerTests;

internal sealed record SerializableRecord(IEnumerable<ulong>? Array, int? Integer, ISerializableInstance? Object, string? String)
    : ISerializableInstance;