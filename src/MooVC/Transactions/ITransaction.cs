namespace MooVC.Transactions
{
    using System;

    public interface ITransaction 
        : IDisposable
    {
        void Begin();

        void Commit();

        void Rollback();
    }
}