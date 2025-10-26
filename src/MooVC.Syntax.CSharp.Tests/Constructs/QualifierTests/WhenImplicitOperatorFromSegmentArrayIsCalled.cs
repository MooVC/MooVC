namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    private static readonly Segment Alpha = new("Alpha");
    private static readonly Segment Beta = new("Beta");

    [Fact]
    public void GivenNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Segment[]? values = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = (Qualifier)values!);

        // Assert
        exception.ParamName.ShouldBe("values");
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        Segment[] values = Array.Empty<Segment>();

        // Act
        Qualifier subject = values;

        // Assert
        subject.ShouldNotBeNull();
        Segment[] result = subject;
        result.ShouldBe(values);
    }

    [Fact]
    public void GivenSegmentsThenRoundTripsSuccessfully()
    {
        // Arrange
        Segment[] values = new[] { Alpha, Beta };

        // Act
        Qualifier subject = values;
        Segment[] result = subject;

        // Assert
        result.ShouldBe(values);
    }

    [Fact]
    public void GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        Segment[] values = new[] { Alpha, Beta };

        // Act
        Qualifier first = values;
        Qualifier second = values;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}
