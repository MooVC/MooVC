namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

public sealed class WhenWithWhitespaceIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        Snippet value = "\t";

        // Act
        Snippet.Options result = options.WithWhitespace(value);

        // Assert
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Whitespace).IsEqualTo(value);
        await Assert.That(options.Whitespace).IsNotEqualTo(value);
    }
}