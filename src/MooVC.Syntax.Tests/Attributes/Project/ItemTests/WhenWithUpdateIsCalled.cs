namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithUpdateIsCalled
{
    private const string UpdatedUpdate = "UpdatedUpdate";

    [Test]
    public async Task GivenUpdateThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From(UpdatedUpdate);

        // Act
        Item result = original.WithUpdate(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Update).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}