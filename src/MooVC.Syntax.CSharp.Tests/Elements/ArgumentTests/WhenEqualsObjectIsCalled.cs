namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    private static readonly Snippet same = Snippet.From("Alpha");
    private static readonly Snippet different = Snippet.From("Beta");

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Argument { Value = same };
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
        var first = new Argument { Value = same };
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
        var left = new Argument { Value = same };
        object right = new Argument { Value = same };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Argument { Value = same };
        object right = new Argument { Value = different };

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = ((Argument)right).Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentTypeThenReturnsFalse()
    {
        // Arrange
        var left = new Argument { Value = same };
        object right = same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}