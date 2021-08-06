namespace MooVC.Serialization
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICloner
    {
        Task<T> CloneAsync<T>(T original, CancellationToken? cancellationToken = default)
            where T : notnull;
    }
}