namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualsQualifierIsCalled
{
    private static readonly ImmutableArray<Segment> Same = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Different = ImmutableArray.Create(new Segment("Gamma"));

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
        Qualifier? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var first = new Qualifier(Same);
        Qualifier second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(Same);
        var right = new Qualifier(Same);

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
        var left = new Qualifier(Same);
        var right = new Qualifier(Different);

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}
