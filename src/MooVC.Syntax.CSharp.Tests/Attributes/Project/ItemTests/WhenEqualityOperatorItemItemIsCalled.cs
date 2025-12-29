namespace MooVC.Syntax.CSharp.Attributes.Project.ItemTests;

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
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}