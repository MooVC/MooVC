namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        Segment[]? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Namespace)value);
    }

    [Fact]
    public void GivenNullWhenRoundTrippedThenResultIsNull()
    {
        // Arrange
        Segment[]? value = default;

        // Act
        Namespace subject = value;
        Segment[]? result = subject;

        // Assert
        result.ShouldBeNull();
    }

    [Fact]
    public void GivenEmptyThenEqualsArray()
    {
        // Arrange
        Segment[] value = Array.Empty<Segment>();

        // Act
        Namespace subject = value;

        // Assert
        subject.Equals(value).ShouldBeTrue();
        (subject == value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenEqualsArray()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta");

        // Act
        Namespace subject = value;

        // Assert
        subject.Equals(value).ShouldBeTrue();
        (subject == value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginal()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta", "Gamma");

        // Act
        Namespace subject = value;
        Segment[]? result = subject;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBe(value);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        Segment[] value = CreateSegments("Alpha", "Beta");

        // Act
        Namespace first = value;
        Namespace second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
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
