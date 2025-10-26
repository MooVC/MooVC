namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenEqualsSegmentArrayIsCalled
{
    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        Segment[]? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        Segment[] right = CreateSegments("Alpha", "Beta");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        Segment[] right = CreateSegments("Alpha", "Gamma");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
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
