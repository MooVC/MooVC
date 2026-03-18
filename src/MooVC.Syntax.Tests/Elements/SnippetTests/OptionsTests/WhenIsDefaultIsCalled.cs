namespace MooVC.Syntax.Elements.SnippetTests.OptionsTests;

public sealed class WhenIsDefaultIsCalled
{
    [Test]
    public void GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var options = new Snippet.Options();

        // Act
        bool result = options.IsDefault;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenNonDefaultValuesThenReturnsFalse()
    {
        // Arrange
        Snippet.Options options = new Snippet.Options()
            .WithWhitespace("\t");

        // Act
        bool result = options.IsDefault;

        // Assert
        result.ShouldBeFalse();
    }
}