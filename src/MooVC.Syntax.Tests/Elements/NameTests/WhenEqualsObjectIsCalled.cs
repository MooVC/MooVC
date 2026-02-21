namespace MooVC.Syntax.Elements.NameTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = Same;
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
        var subject = Same;
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
        var left = Same;
        object right = Same;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = Same;
        object right = Different;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonSegmentThenReturnsFalse()
    {
        // Arrange
        var subject = Same;
        object other = Same;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = Same;
        var right = Same;
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
        var left = Same;
        var right = Different;
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