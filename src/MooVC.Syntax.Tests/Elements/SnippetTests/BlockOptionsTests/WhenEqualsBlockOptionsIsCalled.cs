namespace MooVC.Syntax.Elements.SnippetTests.BlockOptionsTests;

public sealed class WhenEqualsBlockOptionsIsCalled
{
    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BlockOptions();
        Snippet.BlockOptions? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Snippet.BlockOptions();
        Snippet.BlockOptions second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Snippet.BlockOptions();
        var right = new Snippet.BlockOptions();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Snippet.BlockOptions();

        Snippet.BlockOptions right = new Snippet.BlockOptions()
            .WithStyle(Snippet.BlockOptions.StyleType.KAndR);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}