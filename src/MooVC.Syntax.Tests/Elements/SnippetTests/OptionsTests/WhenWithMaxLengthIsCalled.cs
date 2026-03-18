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
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.MaxLength).IsEqualTo(value);
        await Assert.That(options.MaxLength).IsNotEqualTo(value);
    }
}