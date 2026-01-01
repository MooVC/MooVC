namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorItemItemIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Item? left = default;
        Item? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}