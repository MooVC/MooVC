namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualsObjectIsCalled
{
    private static readonly ImmutableArray<Segment> different = ["Gamma"];
    private static readonly ImmutableArray<Segment> same = ["Alpha", "Beta"];

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Qualifier(same);
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        var subject = new Qualifier(same);
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
        object right = new Qualifier(same);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        object right = new Qualifier(different);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonQualifierThenInvalidCastIsThrown()
    {
        // Arrange
        var subject = new Qualifier(same);
        object other = same;

        // Act & Assert
        _ = Should.Throw<InvalidCastException>(() => subject.Equals(other));
    }

    [Fact]
    public void GivenEqualValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = new Qualifier(same);
        var right = new Qualifier(same);
        object leftObject = left;
        object rightObject = right;

        // Act
        bool resultLeftRight = left.Equals(rightObject);
        bool resultRightLeft = right.Equals(leftObject);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = new Qualifier(same);
        var right = new Qualifier(different);
        object leftObject = left;
        object rightObject = right;

        // Act
        bool resultLeftRight = left.Equals(rightObject);
        bool resultRightLeft = right.Equals(leftObject);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }
}