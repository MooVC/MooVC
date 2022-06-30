namespace MooVC.Serialization;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Compression;

public abstract class SynchronousSerializer
    : Serializer
{
    protected SynchronousSerializer(ICompressor? compressor = default)
        : base(compressor: compressor)
    {
    }

    protected override Task<T> PerformDeserializeAsync<T>(Stream source, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformDeserialize<T>(source));
    }

    protected override Task PerformSerializeAsync<T>(T instance, Stream target, CancellationToken? cancellationToken = default)
    {
        PerformSerialize(instance, target);

        return Task.CompletedTask;
    }

    protected abstract T PerformDeserialize<T>(Stream source)
        where T : notnull;

    protected abstract void PerformSerialize<T>(T instance, Stream target)
        where T : notnull;
}