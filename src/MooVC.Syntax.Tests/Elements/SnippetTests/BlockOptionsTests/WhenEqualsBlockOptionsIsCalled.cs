namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests;

public sealed class WhenEqualsBlockOptionsIsCalled
{
    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BlockOptions();
        Snippet.BlockOptions? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet.BlockOptions();
        Snippet.BlockOptions second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.BlockOptions();
        var right = new Snippet.BlockOptions();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        await Assert.That(resultLeftRight).IsTrue();
        await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BlockOptions();

        Snippet.BlockOptions right = new Snippet.BlockOptions()
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        await Assert.That(resultLeftRight).IsFalse();
        await Assert.That(resultRightLeft).IsFalse();
    }
}