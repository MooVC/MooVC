namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenWithOpeningIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BoundaryOptions();
        const string value = "[";

        // Act
        Snippet.BoundaryOptions result = options.WithOpening(value);

        // Assert
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Opening).IsEqualTo(value);
        await Assert.That(options.Opening).IsNotEqualTo(value);
    }
}