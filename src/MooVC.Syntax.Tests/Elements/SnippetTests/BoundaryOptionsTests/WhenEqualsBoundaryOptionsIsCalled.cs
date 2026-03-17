namespace MooVC.Syntax.Elements.SnippetTests.BoundaryOptionsTests;

public sealed class WhenEqualsBoundaryOptionsIsCalled
{
    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BoundaryOptions();
        Snippet.BoundaryOptions? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();
        Snippet.BoundaryOptions second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.BoundaryOptions();
        var right = new Snippet.BoundaryOptions();

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
        var left = new Snippet.BoundaryOptions();

        Snippet.BoundaryOptions right = new Snippet.BoundaryOptions()
            .WithClosing("]");

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}