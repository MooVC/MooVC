namespace MooVC.Syntax.SnippetTests.OptionsTests.BlocksTests.BoundariesTests;

public sealed class WhenInequalityOperatorBoundariesBoundariesIsCalled
{
    [Test]
    public async Task GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Snippet.Options.Blocks.Boundaries? left = default;
        Snippet.Options.Blocks.Boundaries? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();

        Snippet.Options.Blocks.Boundaries right = new()
            .WithClosing("]");

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsTrue();
        _ = await Assert.That(resultRightLeft).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();
        var right = new Snippet.Options.Blocks.Boundaries();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Snippet.Options.Blocks.Boundaries? left = default;
        var right = new Snippet.Options.Blocks.Boundaries();

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.Options.Blocks.Boundaries();
        Snippet.Options.Blocks.Boundaries? right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Snippet.Options.Blocks.Boundaries();
        Snippet.Options.Blocks.Boundaries second = first;

        // Act
        bool result = first != second;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}