namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIdIsCalled
{
    [Test]
    public async Task GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherId");

        // Act
        Item result = original.WithId(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Id).IsEqualTo(updated);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}