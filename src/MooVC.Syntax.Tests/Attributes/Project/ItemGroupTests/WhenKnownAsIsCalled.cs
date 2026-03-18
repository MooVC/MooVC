namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

using MooVC.Syntax.Elements;

public sealed class WhenKnownAsIsCalled
{
    private const string UpdatedLabel = "UpdatedLabel";

    [Test]
    public async Task GivenLabelThenReturnsUpdatedInstance()
    {
        // Arrange
        ItemGroup original = ItemGroupTestsData.Create(item: ItemGroupTestsData.CreateItem());
        var updated = Snippet.From(UpdatedLabel);

        // Act
        ItemGroup result = original.KnownAs(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Label).IsEqualTo(updated);
        _ = await Assert.That(result.Condition).IsEqualTo(original.Condition);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}