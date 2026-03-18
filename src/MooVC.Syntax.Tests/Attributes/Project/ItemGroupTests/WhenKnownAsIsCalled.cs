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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Label).IsEqualTo(updated);
        await Assert.That(result.Condition).IsEqualTo(original.Condition);
        await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}