namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorSnippetImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> _different = ["Gamma"];
    private static readonly ImmutableArray<string> _same = ["Alpha", "Beta"];

    [Test]
    public async Task GivenLeftValueRightDefaultThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(_same);
        ImmutableArray<string> right = default;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(_same);
        ImmutableArray<string> right = _same;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(_same);
        ImmutableArray<string> right = _different;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}