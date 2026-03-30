namespace MooVC.Syntax.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsKAndRIsCalled
{
    [Test]
    public async Task GivenAllmanThenReturnsFalse()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsKAndR;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenKAndRThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.KAndR;

        // Act
        bool result = style.IsKAndR;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}