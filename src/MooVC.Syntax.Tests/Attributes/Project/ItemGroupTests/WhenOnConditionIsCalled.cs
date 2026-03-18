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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Condition).IsEqualTo(updated);
        await Assert.That(result.Items).IsEqualTo(original.Items);
        await Assert.That(result.Label).IsEqualTo(original.Label);
    }
}