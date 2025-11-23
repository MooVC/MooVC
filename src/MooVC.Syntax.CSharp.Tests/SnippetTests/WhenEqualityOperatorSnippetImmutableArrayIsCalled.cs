namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenEqualityOperatorSnippetImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}