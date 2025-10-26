namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenEqualityOperatorQualifierQualifierIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Qualifier? left = default;
        Qualifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Qualifier? left = default;
        var right = new Qualifier(CreateSegments("Alpha", "Beta"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        Qualifier? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        var right = new Qualifier(CreateSegments("Alpha", "Beta"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(CreateSegments("Alpha", "Beta"));
        var right = new Qualifier(CreateSegments("Alpha", "Gamma"));

        // Act
        bool result = left == right;

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
