namespace MooVC.Transactions
{
    using System;
    using System.Threading.Tasks;

    public interface IAsyncTransaction
        : IAsyncDisposable
    {
        Task BeginAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}