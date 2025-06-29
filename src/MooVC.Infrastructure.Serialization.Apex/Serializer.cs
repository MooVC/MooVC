namespace MooVC.Infrastructure.Serialization.Apex;

using global::Apex.Serialization;
using MooVC.Compression;
using MooVC.Serialization;
using static global::Apex.Serialization.Binary;

public sealed class Serializer
    : SynchronousSerializer,
      IDisposable
{
    private readonly IBinary _binary;
    private bool _isDisposed;

    public Serializer(ICompressor? compressor = default, Settings? settings = default)
        : base(compressor: compressor)
    {
        settings ??= new Settings();

        _binary = Create(settings);
    }

    public void Dispose()
    {
        Dispose(isDisposing: true);

        GC.SuppressFinalize(this);
    }

    protected override T PerformDeserialize<T>(Stream source)
    {
        return _binary.Read<T>(source);
    }

    protected override void PerformSerialize<T>(T instance, Stream target)
    {
        _binary.Write(instance, target);
    }

    private void Dispose(bool isDisposing)
    {
        if (!_isDisposed)
        {
            if (isDisposing)
            {
                _binary.Dispose();
            }

            _isDisposed = true;
        }
    }
}