namespace MooVC.Syntax.CSharp.TypeTests.OptionsTests;

public sealed class WhenWithEventsIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Type.Options();
        Event.Options value = Event.Options.Default.WithSnippets(Snippet.Options.Default.WithWhitespace("  "));

        // Act
        Type.Options result = options.WithEvents(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Events).IsEqualTo(value);
        _ = await Assert.That(options.Events).IsNotEqualTo(value);
    }
}