namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenAtIsCalled
{
    [Test]
    public async Task GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("assets/other.txt");

        // Act
        Item result = original.At(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Path).IsEqualTo(updated);
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}