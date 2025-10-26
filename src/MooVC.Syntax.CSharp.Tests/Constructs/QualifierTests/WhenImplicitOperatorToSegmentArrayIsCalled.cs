namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenImplicitOperatorToSegmentArrayIsCalled
{
    [Fact]
    public void GivenNullValueThenResultIsNull()
    {
        // Arrange
        var subject = new Qualifier(default);

        // Act
        Segment[]? result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenMatchesValue()
    {
        // Arrange
        Segment[] value = Array.Empty<Segment>();
        var subject = new Qualifier(value);

        // Act
        Segment[]? result = subject;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenValueThenMatchesArray()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta");
        var subject = new Qualifier(value);

        // Act
        Segment[]? result = subject;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenMultipleSegmentsThenMatchesArray()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta", "Gamma", "Delta");
        var subject = new Qualifier(value);

        // Act
        Segment[]? result = subject;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenRepeatedCallsThenSameArrayIsReturned()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta");
        var subject = new Qualifier(value);

        // Act
        Segment[]? first = subject;
        Segment[]? second = subject;

        // Assert
        first.ShouldBe(second);
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
