namespace MooVC.Syntax.SnippetTests.OptionsTests;

public sealed class WhenEqualsOptionsIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.Options();

        var right = new Snippet.Options()
            .WithMaxLineLength((byte)(Snippet.Options.Default.MaxLineLength - 1));

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
        var left = new Snippet.Options();
        var right = new Snippet.Options();

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
        var left = new Snippet.Options();
        Snippet.Options? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet.Options();
        Snippet.Options second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}