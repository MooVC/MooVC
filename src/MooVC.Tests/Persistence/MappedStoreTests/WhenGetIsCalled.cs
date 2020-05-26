namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using MooVC.Linq;
    using MooVC.Persistence;
    using Moq;
    using Xunit;

    public sealed class WhenGetIsCalled
        : MappedStoreTests
    {
        [Fact]
        public void GivenAKeyThenTheInnerMappingAndInnerStoreAreInvoked()
        {
            bool wasInvoked = false;
            string expectedInnerKey = default;

            string LocalInnerMapping(Guid key)
            {
                wasInvoked = true;

                expectedInnerKey = InnerMapping(key);

                return expectedInnerKey;
            }

            var outterKey = Guid.NewGuid();
            object expectedItem = new object();

            _ = Store
                .Setup(store => store.Get(It.Is<string>(parameter => parameter == expectedInnerKey)))
                .Returns(expectedItem);

            var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

            object actualItem = store.Get(outterKey);

            Assert.True(wasInvoked);
            Assert.Equal(expectedItem, actualItem);

            Store.Verify(store => store.Get(It.IsAny<string>()), times: Times.Once);
        }

        [Fact]
        public void GivenPagingThenTheInnerStoreIsInvoked()
        {
            var paging = new Paging();

            var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            _ = store.Get(paging: paging);

            Store.Verify(store => store.Get(It.IsAny<Paging>()), times: Times.Once);
        }
    }
}