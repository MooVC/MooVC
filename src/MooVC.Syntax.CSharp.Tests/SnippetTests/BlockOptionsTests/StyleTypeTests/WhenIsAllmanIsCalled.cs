namespace MooVC.Syntax.CSharp.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsAllmanIsCalled
{
    [Fact]
    public void GivenAllmanThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsAllman;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenKAndRThenReturnsFalse()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.KAndR;

        // Act
        bool result = style.IsAllman;

        // Assert
        result.ShouldBeFalse();
    }
}
