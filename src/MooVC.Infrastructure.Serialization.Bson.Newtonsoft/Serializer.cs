namespace MooVC.Infrastructure.Serialization.Bson.Newtonsoft;

using System.Collections;
using System.Diagnostics;
using System.Text;
using global::Newtonsoft.Json;
using global::Newtonsoft.Json.Bson;
using MooVC.Compression;
using MooVC.Serialization;
using static System.String;
using static MooVC.Infrastructure.Serialization.Bson.Newtonsoft.Resources;

/// <summary>
/// Provides BSON serialization using Newtonsoft.Json.
/// </summary>
/// <remarks>
/// Serializes through <see cref="BsonDataWriter" /> and deserializes through <see cref="BsonDataReader" />, while honoring configured encoding and date/time kind handling.
/// </remarks>
[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
public sealed class Serializer
    : SynchronousSerializer
{
    /// <summary>
    /// Gets the default text encoding used by the serializer.
    /// </summary>
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;

    /// <summary>
    /// Initializes a new instance of the <see cref="Serializer"/> class.
    /// </summary>
    /// <param name="compressor">The optional stream compressor.</param>
    /// <param name="encoding">The optional text encoding.</param>
    /// <param name="kind">The date time handling mode for BSON data.</param>
    /// <param name="settings">The optional JSON serializer settings.</param>
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

    /// <summary>
    /// Gets the configured text encoding.
    /// </summary>
    public Encoding Encoding { get; }

    /// <summary>
    /// Gets the configured date time kind handling.
    /// </summary>
    public DateTimeKind Kind { get; }

    /// <summary>
    /// Gets the underlying Newtonsoft JSON serializer instance.
    /// </summary>
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

    private string GetDebuggerDisplay()
    {
        return $"{nameof(Serializer)} {{ " +
            $"{nameof(Encoding)} = {DebuggerDisplayFormatter.Format(Encoding)}, " +
            $"{nameof(Json)} = {DebuggerDisplayFormatter.Format(Json)}, " +
            $"{nameof(Kind)} = {DebuggerDisplayFormatter.Format(Kind)} }}";
    }
}