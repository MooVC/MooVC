namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft;

using System.Text;
using global::Newtonsoft.Json;
using MooVC.Compression;
using MooVC.Serialization;
using static System.String;
using static MooVC.Infrastructure.Serialization.Json.Newtonsoft.Resources;

public sealed class Serializer
    : SynchronousSerializer
{
    public new const int DefaultBufferSize = 1024;
    public const int MinimumBufferSize = 8;
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;

    public Serializer(
        int bufferSize = DefaultBufferSize,
        ICompressor? compressor = default,
        Encoding? encoding = default,
        JsonSerializerSettings? settings = default)
        : base(compressor: compressor)
    {
        BufferSize = Math.Max(bufferSize, MinimumBufferSize);
        Encoding = encoding ?? DefaultEncoding;
        Json = JsonSerializer.CreateDefault(settings);
    }

    public int BufferSize { get; }

    public Encoding Encoding { get; }

    public JsonSerializer Json { get; }

    protected override T PerformDeserialize<T>(Stream source)
    {
        using var reader = new StreamReader(source);
        using var text = new JsonTextReader(reader);

        return Json.Deserialize<T>(text)
            ?? throw new JsonSerializationException(Format(SerializerDeserializeFailure, typeof(T)));
    }

    protected override void PerformSerialize<T>(T instance, Stream target)
    {
        using var writer = new StreamWriter(target, Encoding, BufferSize, true);
        using var text = new JsonTextWriter(writer);

        Json.Serialize(text, instance);

        text.Flush();
        writer.Flush();
    }
}