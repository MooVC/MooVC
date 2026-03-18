namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenEqualityOperatorSnippetImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Test]
    public async Task GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = default;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = same;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = different;

        // Act
        bool result = left == right;

        // Assert
        await Assert.That(result).IsFalse();
    }
}