namespace MooVC.Persistence.AsyncMappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Xunit;

    public sealed class WhenAsyncMappedStoreIsConstructed
        : AsyncMappedStoreTests
    {
        [Fact]
        public void GivenAnInnerMappingAnOutterMappingAndANullStoreThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new AsyncMappedStore<object, Guid, string>(InnerMapping, OutterMapping, default!));
        }

        [Fact]
        public void GivenAnInnerMappingAStoreAndANullOutterMappingThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new AsyncMappedStore<object, Guid, string>(InnerMapping, default!, Store.Object));
        }

        [Fact]
        public void GivenAnInnerMappingAnOutterMappingAndAStoreTheInstanceIsConstructed()
        {
            _ = new AsyncMappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);
        }

        [Fact]
        public void GivenAnOutterMappingAStoreAndANullInnerMappingThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new AsyncMappedStore<object, Guid, string>(default!, OutterMapping, Store.Object));
        }
    }
}