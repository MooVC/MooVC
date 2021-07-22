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

        public CancellationToken CancellationToken { get; }

        public static new AsyncEventArgs Empty(CancellationToken? cancellationToken = default)
        {
            if (cancellationToken is { })
            {
                return new AsyncEventArgs(cancellationToken: cancellationToken);
            }

            return empty.Value;
        }
    }
}