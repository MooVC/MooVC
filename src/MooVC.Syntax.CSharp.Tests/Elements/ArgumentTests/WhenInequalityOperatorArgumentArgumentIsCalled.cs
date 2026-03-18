namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorArgumentArgumentIsCalled
{
    private static readonly Snippet same = Snippet.From("Alpha");
    private static readonly Snippet different = Snippet.From("Beta");

    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Argument? left = default;
        Argument? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Argument? left = default;
        var right = new Argument { Value = same };

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Argument { Value = same };
        Argument? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Argument { Value = same };
        Argument second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Argument { Value = same };
        var right = new Argument { Value = same };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Argument { Value = same };
        var right = new Argument { Value = different };

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}