namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenEqualsObjectIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        object? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet(same);
        object second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        object right = new Snippet(same);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        object right = new Snippet(different);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        object right = same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}