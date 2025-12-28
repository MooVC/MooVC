namespace MooVC.Syntax.CSharp.Elements.QualifierTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    private static readonly Segment alpha = new("Alpha");
    private static readonly Segment beta = new("Beta");

    [Fact]
    public void GivenNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Segment[]? values = default;

        // Act
        Func<Qualifier> result = () => values;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        Segment[] values = [];

        // Act
        Qualifier subject = values;

        // Assert
        _ = subject.ShouldNotBeNull();
        Segment[] result = subject;
        result.ShouldBe(values);
    }

    [Fact]
    public void GivenSegmentsThenRoundTripsSuccessfully()
    {
        // Arrange
        Segment[] values = [alpha, beta];

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
        Segment[] values = [alpha, beta];

        // Act
        Qualifier first = values;
        Qualifier second = values;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}