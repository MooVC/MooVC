namespace MooVC.Persistence.MappedStoreTests;

public sealed class WhenCreateAsyncIsCalled
    : MappedStoreTests
{
    [Fact]
    public async Task GivenAnItemThenTheOutterMappingAndInnerStoreAreInvokedAndTheResultFromTheStoreIsReturnedAsync()
    {
        bool wasInvoked = false;

        Guid LocalOutterMapping(object item, string key)
        {
            wasInvoked = true;

            return OutterMapping(item, key);
        }

        // Arrange
        var expectedOutterKey = Guid.NewGuid();
        string expectedInnerKey = expectedOutterKey.ToString();

        object item = new();

        _ = Store
            .CreateAsync(item, Arg.Any<CancellationToken>())
            .Returns(expectedInnerKey);

        var store = new MappedStore<object, Guid, string>(InnerMapping, LocalOutterMapping, Store);

        // Act
        Guid actualOutterKey = await store.CreateAsync(item, CancellationToken.None);

        // Assert
        _ = wasInvoked.Should().BeTrue();
        _ = actualOutterKey.Should().Be(expectedOutterKey);

        _ = await Store.Received(1).CreateAsync(Arg.Any<object>(), Arg.Any<CancellationToken>());
    }
}