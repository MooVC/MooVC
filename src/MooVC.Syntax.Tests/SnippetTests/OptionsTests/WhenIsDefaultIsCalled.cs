namespace MooVC.Syntax.SnippetTests.OptionsTests;

public sealed class WhenIsDefaultIsCalled
{
    [Test]
    public async Task GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var options = new Snippet.Options();

        // Act
        bool result = options.IsDefault;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonDefaultValuesThenReturnsFalse()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithWhitespace("\t");

        // Act
        bool result = options.IsDefault;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}