namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using Shouldly;

public sealed class WhenInequalityOperatorSnippetImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = same;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = different;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}