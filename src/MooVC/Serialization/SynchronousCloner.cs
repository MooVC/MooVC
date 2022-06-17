namespace MooVC.Serialization;

using System.Threading;
using System.Threading.Tasks;

public abstract class SynchronousCloner
    : ICloner
{
    public Task<T> CloneAsync<T>(
        T original,
        CancellationToken? cancellationToken = default)
        where T : notnull
    {
        return Task.FromResult(PerformClone(original));
    }

    protected abstract T PerformClone<T>(T original)
        where T : notnull;
}