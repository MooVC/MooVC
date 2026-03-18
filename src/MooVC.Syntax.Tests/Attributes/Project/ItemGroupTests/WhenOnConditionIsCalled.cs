namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenOnConditionIsCalled
{
    private const string UpdatedCondition = "UpdatedCondition";

    [Test]
    public async Task GivenConditionThenReturnsUpdatedInstance()
    {
        // Arrange
        ItemGroup original = ItemGroupTestsData.Create(item: ItemGroupTestsData.CreateItem());
        var updated = Snippet.From(UpdatedCondition);

        // Act
        ItemGroup result = original.OnCondition(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Condition).IsEqualTo(updated);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
        _ = await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}