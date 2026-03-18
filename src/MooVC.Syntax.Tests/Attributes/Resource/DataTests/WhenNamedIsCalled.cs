namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Data result = original.Named(updated);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(updated);
        await Assert.That(result.Comment).IsEqualTo(original.Comment);
        await Assert.That(result.MimeType).IsEqualTo(original.MimeType);
        await Assert.That(result.Type).IsEqualTo(original.Type);
        await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}