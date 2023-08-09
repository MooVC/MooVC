namespace MooVC.Persistence.MappedStoreTests;

using System;
using FluentAssertions;
using Xunit;

public sealed class WhenMappedStoreIsConstructed
    : MappedStoreTests
{
    [Fact]
    public void GivenAnInnerMappingAnOutterMappingAndANullStoreThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        IStore<object, string>? store = default;

        // Act
        Func<IStore<object, Guid>> act = () => new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, store!);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(store));
    }

    [Fact]
    public void GivenAnInnerMappingAStoreAndANullOutterMappingThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<object, string, Guid>? outterMapping = default;

        // Act
        Func<IStore<object, Guid>> act = () => new MappedStore<object, Guid, string>(InnerMapping, outterMapping!, Store);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(outterMapping));
    }

    [Fact]
    public void GivenAnInnerMappingAnOutterMappingAndAStoreTheInstanceIsConstructed()
    {
        // Act
        var instance = new MappedStore<object, Guid, string>(InnerMapping, OutterMapping, Store);

        // Assert
        _ = instance.Should().NotBeNull();
    }

    [Fact]
    public void GivenAnOutterMappingAStoreAndANullInnerMappingThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        Func<Guid, string>? innerMapping = default;

        // Act
        Func<IStore<object, Guid>> act = () => new MappedStore<object, Guid, string>(innerMapping!, OutterMapping, Store);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>()
            .WithParameterName(nameof(innerMapping));
    }
}