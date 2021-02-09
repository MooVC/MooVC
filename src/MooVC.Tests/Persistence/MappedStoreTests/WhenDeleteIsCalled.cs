namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenDeleteIsCalled
        : MappedStoreTests
    {
        [Fact]
        public void GivenAKeyThenTheInnerMappingAndInnerStoreAreInvoked()
        {
            bool wasInvoked = false;
            string? expectedInnerKey = default;

            string LocalInnerMapping(Guid key)
            {
                wasInvoked = true;

                expectedInnerKey = InnerMapping(key);

                return expectedInnerKey;
            }

            var key = Guid.NewGuid();

            var store = new MappedStore<object, Guid, string>(LocalInnerMapping, OutterMapping, Store.Object);

            store.Delete(key);

            Assert.True(wasInvoked);

            Store.Verify(store => store.Delete(It.IsAny<string>()), times: Times.Once);
            Store.Verify(store => store.Delete(It.Is<string>(argument => argument == expectedInnerKey)), times: Times.Once);
        }

        [Fact]
        public void GivenAnItemThenTheInnerStoreIsInvoked()
        {
            object item = new object();

            var store = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);

            store.Delete(item);

            Store.Verify(store => store.Delete(It.IsAny<object>()), times: Times.Once);
        }
    }
}