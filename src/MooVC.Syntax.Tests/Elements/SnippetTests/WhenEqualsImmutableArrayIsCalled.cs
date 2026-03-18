namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenEqualsImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> different = ["Gamma"];
    private static readonly ImmutableArray<string> same = ["Alpha", "Beta"];

    [Test]
    public void GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet(same);
        ImmutableArray<string> right = same;

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
        ImmutableArray<string> right = different;

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}