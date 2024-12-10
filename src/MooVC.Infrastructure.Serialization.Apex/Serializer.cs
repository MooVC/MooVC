namespace MooVC.Infrastructure.Serialization.Apex;

using global::Apex.Serialization;
using MooVC.Compression;
using MooVC.Serialization;
using static global::Apex.Serialization.Binary;

public sealed class Serializer
    : SynchronousSerializer,
      IDisposable
{
    private readonly IBinary binary;
    private bool isDisposed;

    public Serializer(ICompressor? compressor = default, Settings? settings = default)
        : base(compressor: compressor)
    {
        settings ??= new Settings();

        binary = Create(settings);
    }

    public void Dispose()
    {
        Dispose(isDisposing: true);

        GC.SuppressFinalize(this);
    }

    protected override T PerformDeserialize<T>(Stream source)
    {
        return binary.Read<T>(source);
    }

    protected override void PerformSerialize<T>(T instance, Stream target)
    {
        binary.Write(instance, target);
    }

    private void Dispose(bool isDisposing)
    {
        if (!isDisposed)
        {
            if (isDisposing)
            {
                binary.Dispose();
            }

            isDisposed = true;
        }
    }
}