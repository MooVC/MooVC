namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorQualifierQualifierIsCalled
{
    private static readonly ImmutableArray<Segment> Same = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Different = ImmutableArray.Create(new Segment("Gamma"));

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Qualifier? left = default;
        Qualifier? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Qualifier? left = default;
        var right = new Qualifier(Same);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(Same);
        Qualifier? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        var first = new Qualifier(Same);
        Qualifier second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
        var right = new Qualifier(Same);

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
        var left = new Qualifier(Same);
        var right = new Qualifier(Different);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
