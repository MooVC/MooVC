namespace MooVC.Syntax.CSharp.SnippetTests.OptionsTests;

public sealed class WhenIsDefaultIsCalled
{
    [Fact]
    public void GivenDefaultValuesThenReturnsTrue()
    {
        // Arrange
        var options = new Snippet.Options();

        // Act
        bool result = options.IsDefault;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenNonDefaultValuesThenReturnsFalse()
    {
        // Arrange
        var options = new Snippet.Options()
            .WithWhitespace("\t");

        // Act
        bool result = options.IsDefault;

        // Assert
        result.ShouldBeFalse();
    }
}
