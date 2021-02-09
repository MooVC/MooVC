namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using Moq;
    using Xunit;

    public sealed class WhenCreateIsCalled
        : MappedStoreTests
    {
        [Fact]
        public void GivenAnItemThenTheOutterMappingAndInnerStoreAreInvokedAndTheResultFromTheStoreIsReturned()
        {
            bool wasInvoked = false;

            Guid LocalOutterMapping(object item, string key)
            {
                wasInvoked = true;

                return OutterMapping(item, key);
            }

            var expectedOutterKey = Guid.NewGuid();
            string expectedInnerKey = expectedOutterKey.ToString();

            object item = new object();

            _ = Store
                .Setup(store => store.Create(It.Is<object>(parameter => parameter == item)))
                .Returns(expectedInnerKey);

            var store = new MappedStore<object, Guid, string>(InnerMapping, LocalOutterMapping, Store.Object);
            Guid actualOutterKey = store.Create(item);

            Assert.True(wasInvoked);
            Assert.Equal(expectedOutterKey, actualOutterKey);

            Store.Verify(store => store.Create(It.IsAny<object>()), times: Times.Once);
        }
    }
}