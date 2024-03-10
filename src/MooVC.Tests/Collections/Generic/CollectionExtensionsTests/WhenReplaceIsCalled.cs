namespace MooVC.Collections.Generic.CollectionExtensionsTests;

public sealed class WhenReplaceIsCalled
{
    [Fact]
    public void GivenANullListThenNoArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int> target = [];
        IEnumerable<int>? items = default;

        // Act
        Action act = () => target.Replace(items);

        // Assert
        _ = act.Should().NotThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenANullTargetThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        ICollection<int>? target = default;
        int[] items = [1, 2, 3];

        // Act
        Action act = () => target!.Replace(items);

        // Assert
        _ = act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsEmptyThenTheItemsAreAddedToTheTarget()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] expected = [1, 2, 3];

        // Act
        actual.Replace(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenItemsWhenTheTargetIsNotEmptyThenTheItemsAreAddedToTheTargetAndTheExistingEntriesAreRemoved()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] expected = [4, 5, 6];

        // Act
        actual.Replace(expected);

        // Assert
        _ = actual.Should().Equal(expected);
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsEmptyThenTargetRemainsEmpty()
    {
        // Arrange
        ICollection<int> actual = [];
        int[] items = [];

        // Act
        actual.Replace(items);

        // Assert
        _ = actual.Should().BeEmpty();
    }

    [Fact]
    public void GivenAnEmptyItemListWhenTargetIsNotEmptyThenTargetBecomesEmpty()
    {
        // Arrange
        ICollection<int> actual = [1, 2, 3];
        int[] items = [];

        // Act
        actual.Replace(items);

        // Assert
        _ = actual.Should().BeEmpty();
    }
}