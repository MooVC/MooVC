namespace MooVC.Syntax.Attributes.Project.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create(metadata: ItemTestsData.CreateMetadata());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        Item result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.Exclude).IsEqualTo(original.Exclude);
        _ = await Assert.That(result.Include).IsEqualTo(original.Include);
    }
}