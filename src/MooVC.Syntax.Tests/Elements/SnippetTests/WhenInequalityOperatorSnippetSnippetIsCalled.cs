namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorSnippetSnippetIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Snippet? left = default;
        Snippet? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Snippet? left = default;
        var right = new Snippet(same);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        Snippet? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Snippet(same);
        Snippet second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        var right = new Snippet(same);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        var right = new Snippet(different);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}