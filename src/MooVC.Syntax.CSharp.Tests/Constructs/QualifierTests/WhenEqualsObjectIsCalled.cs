namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualsObjectIsCalled
{
    private static readonly ImmutableArray<Segment> Same = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Different = ImmutableArray.Create(new Segment("Gamma"));

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Qualifier(Same);
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
        var subject = new Qualifier(Same);
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
        var left = new Qualifier(Same);
        object right = new Qualifier(Same);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(Same);
        object right = new Qualifier(Different);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonQualifierThenInvalidCastIsThrown()
    {
        // Arrange
        var subject = new Qualifier(Same);
        object other = Same;

        // Act & Assert
        _ = Should.Throw<InvalidCastException>(() => subject.Equals(other));
    }

    [Fact]
    public void GivenEqualValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = new Qualifier(Same);
        var right = new Qualifier(Same);
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
        var left = new Qualifier(Same);
        var right = new Qualifier(Different);
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
