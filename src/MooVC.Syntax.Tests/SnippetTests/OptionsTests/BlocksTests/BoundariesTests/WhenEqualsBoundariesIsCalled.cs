namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.BoundariesTests;

public sealed class WhenEqualsBoundariesIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();

        Snippet.Options.Blocks.Boundaries right = new()
            .WithClosing("]");

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();
        var right = new Snippet.Options.Blocks.Boundaries();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();
        Snippet.Options.Blocks.Boundaries? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet.Options.Blocks.Boundaries();
        Snippet.Options.Blocks.Boundaries second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}