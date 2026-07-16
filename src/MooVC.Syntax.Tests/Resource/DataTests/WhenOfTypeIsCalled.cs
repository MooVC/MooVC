namespace MooVC.Syntax.Resource.DataTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Data result = original.OfType(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Type).IsEqualTo(updated);
        _ = await Assert.That(result.Comment).IsEqualTo(original.Comment);
        _ = await Assert.That(result.MimeType).IsEqualTo(original.MimeType);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Value).IsEqualTo(original.Value);
    }
}