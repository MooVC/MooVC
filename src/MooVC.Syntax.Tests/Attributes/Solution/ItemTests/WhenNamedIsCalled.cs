namespace MooVC.Syntax.Attributes.Solution.ItemTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Item original = ItemTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        Item result = original.Named(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(updated);
        await Assert.That(result.Id).IsEqualTo(original.Id);
        await Assert.That(result.Path).IsEqualTo(original.Path);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Items).IsEqualTo(original.Items);
    }
}