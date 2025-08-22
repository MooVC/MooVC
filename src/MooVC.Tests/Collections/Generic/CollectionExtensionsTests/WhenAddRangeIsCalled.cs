namespace MooVC.Collections.Generic.CollectionExtensionsTests;

public sealed class WhenAddRangeIsCalled
{
    [Fact]
    public void GivenANullListThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int> target = [];
        IEnumerable<int>? items = default;

        // Act
        Action act = () => target.AddRange(items);

        // Assert
        Should.NotThrow(act);
    }

    [Fact]
    public void GivenANullTargetThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int>? target = default;
        int[] items = [1, 2, 3];

        // Act
        Action act = () => target!.AddRange(items);

        // Assert
        Should.Throw<ArgumentNullException>(act);
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] expected = [1, 2, 3];

        // Act
        actual.AddRange(expected);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetWithoutRemovingTheExistingEntries()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] items = [4, 5, 6];
        IEnumerable<int> expected = [1, 2, 3, 4, 5, 6];

        // Act
        actual.AddRange(items);

        // Assert
        actual.ShouldBe(expected);
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsEmptyThenTargetRemainsEmpty()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] items = [];

        // Act
        actual.AddRange(items);

        // Assert
        actual.ShouldBeEmpty();
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsNotEmptyThenTargetRemainsUnchanged()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] items = [];

        // Act
        actual.AddRange(items);

        // Assert
        actual.ShouldBe([1, 2, 3]);
    }
}