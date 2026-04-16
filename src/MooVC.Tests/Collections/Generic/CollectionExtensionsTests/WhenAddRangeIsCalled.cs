namespace MooVC.Collections.Generic.CollectionExtensionsTests;

public sealed class WhenAddRangeIsCalled
{
    [Test]
    public async Task GivenAnEmptyItemListWhenTargetIsEmptyThenTargetRemainsEmpty()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] items = [];

        // Act
        actual.AddRange(items);

        // Assert
        _ = await Assert.That(actual).IsEmpty();
    }

    [Test]
    public async Task GivenAnEmptyItemListWhenTargetIsNotEmptyThenTargetRemainsUnchanged()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] items = [];

        // Act
        actual.AddRange(items);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo([1, 2, 3]);
    }

    [Test]
    public async Task GivenANullListThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int> target = [];
        IEnumerable<int>? items = default;

        // Act
        Action act = () => target.AddRange(items);

        // Assert
        _ = await Assert.That(act).ThrowsNothing();
    }

    [Test]
    public async Task GivenANullTargetThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int>? target = default;
        int[] items = [1, 2, 3];

        // Act
        Action act = () => target!.AddRange(items);

        // Assert
        _ = await Assert.That(act).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] expected = [1, 2, 3];

        // Act
        actual.AddRange(expected);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }

    [Test]
    public async Task GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetWithoutRemovingTheExistingEntries()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] items = [4, 5, 6];
        IEnumerable<int> expected = [1, 2, 3, 4, 5, 6];

        // Act
        actual.AddRange(items);

        // Assert
        _ = await Assert.That(actual).IsEquivalentTo(expected);
    }
}