namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using Moq;

    public abstract class MappedStoreTests
    {
        protected MappedStoreTests()
        {
            InnerMapping = key => key.ToString();
            OutterMapping = (item, key) => new Guid(key);
            Store = new Mock<IStore<object, string>>();
        }

        protected Func<Guid, string> InnerMapping { get; }

        protected Func<object, string, Guid> OutterMapping { get; }

        protected Mock<IStore<object, string>> Store { get; }
    }
}