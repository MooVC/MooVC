#if NET5_0_OR_GREATER
namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft.SerializerTests;

internal sealed record SerializableRecord(IEnumerable<ulong>? Array, int? Integer, ISerializableInstance? Object, string? String)
    : ISerializableInstance;
#endif