namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsKAndRIsCalled
{
    [Test]
    public async Task GivenKAndRThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.KAndR;

        // Act
        bool result = style.IsKAndR;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenAllmanThenReturnsFalse()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsKAndR;

        // Assert
        await Assert.That(result).IsFalse();
    }
}