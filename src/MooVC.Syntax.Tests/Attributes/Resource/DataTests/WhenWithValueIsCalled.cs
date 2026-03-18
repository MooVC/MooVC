namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Data result = original.WithValue(updated);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Value).IsEqualTo(updated);
        _ = await Assert.That(result.Comment).IsEqualTo(original.Comment);
        _ = await Assert.That(result.MimeType).IsEqualTo(original.MimeType);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Type).IsEqualTo(original.Type);
    }
}