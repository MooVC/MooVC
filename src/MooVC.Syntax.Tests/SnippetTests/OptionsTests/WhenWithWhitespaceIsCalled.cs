namespace MooVC.Syntax.SnippetTests.OptionsTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Whitespace).IsEqualTo(value);
        _ = await Assert.That(options.Whitespace).IsNotEqualTo(value);
    }
}