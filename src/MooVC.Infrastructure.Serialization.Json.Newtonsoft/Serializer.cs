namespace MooVC.Infrastructure.Serialization.Json.Newtonsoft;

using System.Text;
using global::Newtonsoft.Json;
using MooVC.Compression;
using MooVC.Serialization;
using static System.String;
using static MooVC.Infrastructure.Serialization.Json.Newtonsoft.Resources;

/// <summary>
/// Provides JSON serialization using Newtonsoft.Json.
/// </summary>
/// <remarks>
/// Uses streaming readers/writers to avoid unnecessary intermediate buffers and supports optional compression via the base serializer abstraction.
/// </remarks>
public sealed class Serializer
    : SynchronousSerializer
{
    /// <summary>
    /// Represents the default write buffer size.
    /// </summary>
    public new const int DefaultBufferSize = 1024;

    /// <summary>
    /// Represents the minimum allowed write buffer size.
    /// </summary>
    public const int MinimumBufferSize = 8;

    /// <summary>
    /// Gets the default text encoding used by the serializer.
    /// </summary>
    public static readonly Encoding DefaultEncoding = Encoding.UTF8;

    /// <summary>
    /// Initializes a new instance of the <see cref="Serializer"/> class.
    /// </summary>
    /// <param name="bufferSize">The write buffer size.</param>
    /// <param name="compressor">The optional stream compressor.</param>
    /// <param name="encoding">The optional text encoding.</param>
    /// <param name="settings">The optional JSON serializer settings.</param>
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

    /// <summary>
    /// Gets the configured write buffer size.
    /// </summary>
    public int BufferSize { get; }

    /// <summary>
    /// Gets the configured text encoding.
    /// </summary>
    public Encoding Encoding { get; }

    /// <summary>
    /// Gets the underlying Newtonsoft JSON serializer instance.
    /// </summary>
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