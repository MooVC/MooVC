namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

public sealed class WhenEqualityOperatorNamespaceNamespaceIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Namespace? left = default;
        Namespace? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Namespace? left = default;
        var right = new Namespace(CreateSegments("Alpha", "Beta"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        Namespace? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        var right = new Namespace(CreateSegments("Alpha", "Beta"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Namespace(CreateSegments("Alpha", "Beta"));
        var right = new Namespace(CreateSegments("Alpha", "Gamma"));

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
