namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithPropertiesIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Property.Options value = Property.Options.Default.WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        Type.Options result = options.WithProperties(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Properties).IsEqualTo(value);
        _ = await Assert.That(options.Properties).IsNotEqualTo(value);
    }
}