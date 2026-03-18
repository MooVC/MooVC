namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

public sealed class WhenWithMaxLengthIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Snippet.Options();
        const byte value = 200;

        // Act
        Snippet.Options result = options.WithMaxLength(value);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(options);
        _ = await Assert.That(result.MaxLength).IsEqualTo(value);
        _ = await Assert.That(options.MaxLength).IsNotEqualTo(value);
    }
}