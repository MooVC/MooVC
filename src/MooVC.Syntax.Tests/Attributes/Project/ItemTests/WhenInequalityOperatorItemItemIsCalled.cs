namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorItemItemIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Item left = ItemTestsData.Create();
        Item right = ItemTestsData.Create(update: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}