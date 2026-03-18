namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenWithClosingIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.BoundaryOptions();
        const string value = "]";

        // Act
        Snippet.BoundaryOptions result = options.WithClosing(value);

        // Assert
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Closing).IsEqualTo(value);
        await Assert.That(options.Closing).IsNotEqualTo(value);
    }
}