namespace MooVC.Syntax.CSharp.Members.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenInequalityOperatorQualifierQualifierIsCalled
{
    private static readonly ImmutableArray<Segment> different = ["Gamma"];
    private static readonly ImmutableArray<Segment> same = ["Alpha", "Beta"];

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
        var right = new Qualifier(same);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
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
        var first = new Qualifier(same);
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
        var left = new Qualifier(same);
        var right = new Qualifier(same);

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
        var left = new Qualifier(same);
        var right = new Qualifier(different);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}