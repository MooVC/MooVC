namespace MooVC.Syntax.Elements.QualifierTests;

public sealed class WhenImplicitOperatorFromSegmentArrayIsCalled
{
    private static readonly Name alpha = new("Alpha");
    private static readonly Name beta = new("Beta");

    [Fact]
    public void GivenNullThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Name[]? values = default;

        // Act
        Func<Qualifier> result = () => values;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        Name[] values = [];

        // Act
        Qualifier subject = values;

        // Assert
        _ = subject.ShouldNotBeNull();
        Name[] result = subject;
        result.ShouldBe(values);
    }

    [Fact]
    public void GivenSegmentsThenRoundTripsSuccessfully()
    {
        // Arrange
        Name[] values = [alpha, beta];

        // Act
        Qualifier subject = values;
        Name[] result = subject;

        // Assert
        result.ShouldBe(values);
    }

    [Fact]
    public void GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        Name[] values = [alpha, beta];

        // Act
        Qualifier first = values;
        Qualifier second = values;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}