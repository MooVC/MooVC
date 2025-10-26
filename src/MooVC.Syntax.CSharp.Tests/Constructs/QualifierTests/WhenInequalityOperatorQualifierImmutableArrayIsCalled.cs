namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorQualifierImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Segment> Same = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Different = ImmutableArray.Create(new Segment("Gamma"));

    [Fact]
    public void GivenLeftValueRightDefaultThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(Same);
        ImmutableArray<Segment> right = default;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
        ImmutableArray<Segment> right = Same;

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
        ImmutableArray<Segment> right = Different;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}
