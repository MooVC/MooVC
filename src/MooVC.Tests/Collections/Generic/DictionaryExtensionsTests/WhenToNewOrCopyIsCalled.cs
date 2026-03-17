namespace MooVC.Collections.Generic.DictionaryExtensionsTests;

public sealed class WhenToNewOrCopyIsCalled
{
    [Test]
    public void GivenANullDictionaryThenAnEmptyDictionaryIsReturned()
    {
        // Arrange
        IDictionary<string, object>? original = default;

        // Act
        IDictionary<string, object>? snapshot = original.ToNewOrCopy();

        // Assert
        _ = snapshot.ShouldNotBeNull();
        snapshot.ShouldBeEmpty();
    }

    [Test]
    public void GivenADictionaryThenACloneIsReturned()
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
        snapshot.ShouldNotBeSameAs(original);
        snapshot.ShouldBe(original);
    }

    [Test]
    public void GivenAnEmptyDictionaryThenAnEmptyCloneIsReturned()
    {
        // Arrange
        IDictionary<string, int>? original = new Dictionary<string, int>();

        // Act
        IDictionary<string, int>? snapshot = original.ToNewOrCopy();

        // Assert
        snapshot.ShouldNotBeSameAs(original);
        snapshot.ShouldBe(original);
    }
}