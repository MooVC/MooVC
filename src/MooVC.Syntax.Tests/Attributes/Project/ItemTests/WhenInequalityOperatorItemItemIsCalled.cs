namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorItemItemIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}