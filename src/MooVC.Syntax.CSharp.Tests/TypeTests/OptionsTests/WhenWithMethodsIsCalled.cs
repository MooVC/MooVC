namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Method.Options value = Method.Options.Default.WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        Type.Options result = options.WithMethods(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Methods).IsEqualTo(value);
        _ = await Assert.That(options.Methods).IsNotEqualTo(value);
    }
}