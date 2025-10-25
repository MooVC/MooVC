namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Same = "Alpha";
    private const string Different = "Beta";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Member(Same);
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
        var subject = new Member(Same);
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
        var left = new Member(Same);
        object right = new Member(Same);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Member(Same);
        object right = new Member(Different);

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonMemberThenInvalidCastIsThrown()
    {
        // Arrange
        var subject = new Member(Same);
        object other = Same;

        // Act & Assert
        _ = Should.Throw<InvalidCastException>(() => subject.Equals(other));
    }

    [Fact]
    public void GivenEqualValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = new Member(Same);
        var right = new Member(Same);
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
        var left = new Member(Same);
        var right = new Member(Different);
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