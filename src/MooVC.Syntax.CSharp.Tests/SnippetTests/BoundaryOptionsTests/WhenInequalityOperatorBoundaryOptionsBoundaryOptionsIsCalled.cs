namespace MooVC.Syntax.CSharp.SnippetTests.BoundaryOptionsTests;

public sealed class WhenInequalityOperatorBoundaryOptionsBoundaryOptionsIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Snippet.BoundaryOptions? left = default;
        Snippet.BoundaryOptions? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Snippet.BoundaryOptions? left = default;
        var right = new Snippet.BoundaryOptions();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.BoundaryOptions();
        Snippet.BoundaryOptions? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Snippet.BoundaryOptions();
        Snippet.BoundaryOptions second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BoundaryOptions();
        var right = new Snippet.BoundaryOptions();

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
        var left = new Snippet.BoundaryOptions();
        var right = new Snippet.BoundaryOptions()
            .WithClosing("]");

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
