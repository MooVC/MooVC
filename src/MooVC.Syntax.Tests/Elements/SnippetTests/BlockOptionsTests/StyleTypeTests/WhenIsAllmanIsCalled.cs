namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsAllmanIsCalled
{
    [Test]
    public void GivenAllmanThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsAllman;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
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