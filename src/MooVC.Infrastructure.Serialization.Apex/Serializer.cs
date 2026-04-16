namespace MooVC.Infrastructure.Serialization.Apex;

using global::Apex.Serialization;
using MooVC.Compression;
using MooVC.Serialization;
using static global::Apex.Serialization.Binary;

/// <summary>
/// Provides Apex binary serialization.
/// </summary>
/// <remarks>
/// Wraps the Apex <see cref="IBinary" /> serializer and integrates with MooVC compression via <see cref="SynchronousSerializer" />.
/// </remarks>
public sealed class Serializer
    : SynchronousSerializer,
      IDisposable
{
    private readonly IBinary _binary;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Serializer"/> class.
    /// </summary>
    /// <param name="compressor">The optional stream compressor.</param>
    /// <param name="settings">The Apex serializer settings.</param>
    public Serializer(ICompressor? compressor = default, Settings? settings = default)
        : base(compressor: compressor)
    {
        settings ??= new Settings();

        _binary = Create(settings);
    }

    /// <summary>
    /// Releases managed resources used by the serializer.
    /// </summary>
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