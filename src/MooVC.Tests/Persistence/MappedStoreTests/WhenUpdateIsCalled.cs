namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenUpdateIsCalled
        : MappedStoreTests
    {
        [Fact]
        public void GivenAnItemThenTheInnerStoreIsInvoked()
        {
            var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            store.Update(new object());

            Store.Verify(store => store.Update(It.IsAny<object>()), times: Times.Once);
        }
    }
}