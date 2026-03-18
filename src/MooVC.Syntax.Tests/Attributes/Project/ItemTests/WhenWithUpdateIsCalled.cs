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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Update).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}