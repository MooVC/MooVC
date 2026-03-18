namespace MooVC.Collections.Generic.DictionaryExtensionsTests;

public sealed class WhenToNewOrCopyIsCalled
{
    [Test]
    public async Task GivenANullDictionaryThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IDictionary<string, object>? original = default;

        // Act
        IDictionary<string, object>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = await Assert.That(snapshot).IsNotNull();
        _ = await Assert.That(snapshot).IsEmpty();
    }

    [Test]
    public async Task GivenADictionaryThenACloneIsReturned()
    {
        // Arrange
        IDictionary<string, int>? original = new Dictionary<string, int>
        {
            { "First", 1 },
            { "Second", 2 },
        };

        // Act
        IDictionary<string, int>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = await Assert.That(snapshot).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(snapshot).IsEquivalentTo(original);
    }

    [Test]
    public async Task GivenAnEmptyDictionaryThenAnEmptyCloneIsReturned()
    {
        // Arrange
        IDictionary<string, int>? original = new Dictionary<string, int>();

        // Act
        IDictionary<string, int>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = await Assert.That(snapshot).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(snapshot).IsEquivalentTo(original);
    }
}