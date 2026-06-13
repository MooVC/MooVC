namespace MooVC.Syntax.SnippetTests.OptionsTests;

public sealed class WhenWithMaxLineLengthIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        const byte value = 200;

        // Act
        Snippet.Options result = options.WithMaxLineLength(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.MaxLineLength).IsEqualTo(value);
        _ = await Assert.That(options.MaxLineLength).IsNotEqualTo(value);
    }
}