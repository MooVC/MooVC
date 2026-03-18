namespace MooVC.Syntax.Elements.IdentifierTests;

public sealed class WhenEqualityOperatorIdentifierIdentifierIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Identifier? left = default;
        Identifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Identifier? left = default;
        var right = new Identifier(Same);

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        Identifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Identifier(Same);
        Identifier second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Identifier(Same);
        var right = new Identifier(Same);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Identifier(Same);
        var right = new Identifier(Different);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}