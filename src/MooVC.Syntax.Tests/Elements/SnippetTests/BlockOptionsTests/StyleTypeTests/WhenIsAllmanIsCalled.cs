namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests.StyleTypeTests;

public sealed class WhenIsAllmanIsCalled
{
    [Test]
    public async Task GivenAllmanThenReturnsTrue()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.Allman;

        // Act
        bool result = style.IsAllman;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenKAndRThenReturnsFalse()
    {
        // Arrange
        Snippet.BlockOptions.StyleType style = Snippet.BlockOptions.StyleType.KAndR;

        // Act
        bool result = style.IsAllman;

        // Assert
        await Assert.That(result).IsFalse();
    }
}