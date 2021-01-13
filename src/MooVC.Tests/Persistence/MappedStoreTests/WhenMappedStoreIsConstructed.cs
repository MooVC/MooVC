namespace MooVC.Persistence.MappedStoreTests
{
    using System;
    using MooVC.Persistence;
    using Xunit;

    public sealed class WhenMappedStoreIsConstructed
        : MappedStoreTests
    {
        [Fact]
        public void GivenAnInnerMappingAnOutterMappingAndANullStoreThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, default!));
        }

        [Fact]
        public void GivenAnInnerMappingAStoreAndANullOutterMappingThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new MappedStore<object, Guid, string>(InnerMapping, default!, Store.Object));
        }

        [Fact]
        public void GivenAnInnerMappingAnOutterMappingAndAStoreTheInstanceIsConstructed()
        {
            _ = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store.Object);
        }

        [Fact]
        public void GivenAnOutterMappingAStoreAndANullInnerMappingThenAnArgumentNullExceptionIsThrown()
        {
            _ = Assert.Throws<ArgumentNullException>(
                () => new MappedStore<object, Guid, string>(default!, OutterMapping, Store.Object));
        }
    }
}