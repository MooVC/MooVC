namespace MooVC.Serialization.SerializerTests;

using System.IO;
using MooVC.Compression;

public sealed class TestableSerializer
    : Serializer
{
    private readonly Func<Stream, object>? _onDeserialize;
    private readonly Func<object, Stream, Task>? _onSerialize;

    public TestableSerializer(
        int bufferSize = DefaultBufferSize,
        ICompressor? compressor = default,
        Func<Stream, object>? onDeserialize = default,
        Func<object, Stream, Task>? onSerialize = default)
        : base(bufferSize: bufferSize, compressor: compressor)
    {
        _onDeserialize = onDeserialize;
        _onSerialize = onSerialize;
    }

    protected override Task<T> PerformDeserialize<T>(Stream source, CancellationToken cancellationToken)
    {
        object output = _onDeserialize?.Invoke(source)
            ?? throw new InvalidOperationException("Deserializer callback is required.");

        return Task.FromResult((T)output);
    }

    protected override Task PerformSerialize<T>(T instance, Stream target, CancellationToken cancellationToken)
    {
        return _onSerialize?.Invoke(instance!, target)
            ?? throw new InvalidOperationException("Serializer callback is required.");
    }
}
