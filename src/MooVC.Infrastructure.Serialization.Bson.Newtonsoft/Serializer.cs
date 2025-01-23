namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft;

using System.Collections;
using System.Text;
using global::Newtonsoft.Json;
using global::Newtonsoft.Json.Bson;
using MooVC.Compression;
using MooVC.Serialization;
using static System.String;
using static MooVC.Infrastructure.Serialization.Bson.Newtonsoft.Resources;

public sealed class Serializer
    : SynchronousSerializer
{
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public Serializer(
        ICompressor? compressor = default,
        Encoding? encoding = default,
        DateTimeKind kind = DateTimeKind.Unspecified,
        JsonSerializerSettings? settings = default)
        : base(compressor: compressor)
    {
        Encoding = encoding ?? DefaultEncoding;
        Kind = kind;
        Json = JsonSerializer.CreateDefault(settings);
    }

    public Encoding Encoding { get; }

    public DateTimeKind Kind { get; }

    public JsonSerializer Json { get; }

    protected override T PerformDeserialize<T>(Stream source)
    {
        Type type = typeof(T);
        bool readRootValueAsArray = typeof(IEnumerable).IsAssignableFrom(type) || type.IsArray;

        using var binary = new BinaryReader(source, Encoding, true);
        using var reader = new BsonDataReader(source, readRootValueAsArray, Kind);

        return Json.Deserialize<T>(reader)
            ?? throw new JsonSerializationException(Format(SerializerDeserializeFailure, typeof(T)));
    }

    protected override void PerformSerialize<T>(T instance, Stream target)
    {
        using var binary = new BinaryWriter(target, Encoding, true);

        using var writer = new BsonDataWriter(binary)
        {
            DateTimeKindHandling = Kind,
        };

        Json.Serialize(writer, instance);

        writer.Flush();
        binary.Flush();
    }
}