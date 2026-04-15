namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithAttributesIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Attribute.Options value = Attribute.Options.Separate.WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        Type.Options result = options.WithAttributes(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Attributes).IsEqualTo(value);
        _ = await Assert.That(options.Attributes).IsNotEqualTo(value);
    }
}
