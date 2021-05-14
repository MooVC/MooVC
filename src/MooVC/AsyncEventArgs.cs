namespace MooVC
{
    using System;
    using System.Threading;

    public class AsyncEventArgs
        : EventArgs
    {
        private static readonly Lazy<AsyncEventArgs> empty = new(() => new AsyncEventArgs());

        protected AsyncEventArgs(CancellationToken? cancellationToken = default)
        {
            CancellationToken = cancellationToken.GetValueOrDefault();
        }

        public static new AsyncEventArgs Empty => empty.Value;

        public CancellationToken CancellationToken { get; }
    }
}