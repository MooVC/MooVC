namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        var subject = new Namespace(CreateSegments("Alpha", "Beta"));
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
        var subject = new Namespace(CreateSegments("Alpha", "Beta"));
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
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        object right = new Namespace(CreateSegments("Alpha", "Beta"));

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        object right = new Namespace(CreateSegments("Alpha", "Gamma"));

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonNamespaceThenInvalidCastIsThrown()
    {
        // Arrange
        var subject = new Namespace(CreateSegments("Alpha", "Beta"));
        object other = CreateSegments("Alpha", "Beta");

        // Act & Assert
        _ = Should.Throw<InvalidCastException>(() => subject.Equals(other));
    }

    [Fact]
    public void GivenEqualValuesFromBothSidesThenResultsAreSymmetric()
    {
        // Arrange
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        var right = new Namespace(CreateSegments("Alpha", "Beta"));
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
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        var right = new Namespace(CreateSegments("Alpha", "Gamma"));
        object leftObject = left;
        object rightObject = right;

        // Act
        bool resultLeftRight = left.Equals(rightObject);
        bool resultRightLeft = right.Equals(leftObject);

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    private static Segment[] CreateSegments(params string[] values)
    {
        var segments = new Segment[values.Length];

        for (int index = 0; index < values.Length; index++)
        {
            segments[index] = new Segment(values[index]);
        }

        return segments;
    }
}
