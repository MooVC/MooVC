namespace MooVC.Persistence.AsyncMappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Moq;

    public abstract class AsyncMappedStoreTests
    {
        protected AsyncMappedStoreTests()
        {
            InnerMapping = key => key.ToString();
            OutterMapping = (item, key) => new Guid(key);
            Store = new Mock<IAsyncStore<object, string>>();
        }

        protected Func<Guid, string> InnerMapping { get; }

        protected Func<object, string, Guid> OutterMapping { get; }

        protected Mock<IAsyncStore<object, string>> Store { get; }
    }
}