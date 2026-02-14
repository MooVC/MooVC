namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsKAndRIsCalled
{
    [Fact]
    public void GivenKAndRThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.KAndR;

        // Act
        bool result = style.IsKAndR;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenAllmanThenReturnsFalse()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsKAndR;

        // Assert
        result.ShouldBeFalse();
    }
}