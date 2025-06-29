namespace MooVC.Serialization.SynchronousSerializerTests;

using System.IO;
using MooVC.Compression;

public sealed class TestableSynchronousSerializer
    : SynchronousSerializer
{
    private readonly Func<object, object>? _onDeserialize;
    private readonly Action<object, Stream>? _onSerialize;

    public TestableSynchronousSerializer(
        ICompressor? compressor = default,
        Func<object, object>? onDeserialize = default,
        Action<object, Stream>? onSerialize = default)
        : base(compressor: compressor)
    {
        _onDeserialize = onDeserialize;
        _onSerialize = onSerialize;
    }

    protected override T PerformDeserialize<T>(Stream source)
    {
        return (T)_onDeserialize!.Invoke(source);
    }

    protected override void PerformSerialize<T>(T instance, Stream target)
    {
        _onSerialize!.Invoke(instance, target);
    }
}