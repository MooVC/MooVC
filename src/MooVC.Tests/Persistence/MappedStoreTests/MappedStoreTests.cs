namespace MooVC.Persistence.MappedStoreTests;

using System;
using NSubstitute;

public abstract class MappedStoreTests
{
    protected MappedStoreTests()
    {
        InnerMapping = key => key.ToString();
        OutterMapping = (item, key) => new Guid(key);
        Store = Substitute.For<IStore<object, string>>();
    }

    protected Func<Guid, string> InnerMapping { get; }

    protected Func<object, string, Guid> OutterMapping { get; }

    protected IStore<object, string> Store { get; }
}