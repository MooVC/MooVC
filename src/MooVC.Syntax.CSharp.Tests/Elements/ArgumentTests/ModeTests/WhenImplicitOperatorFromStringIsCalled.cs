namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "in";

    [Fact]
    public void GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        string? provided = default;

        // Act
        Argument.Mode subject = provided!;

        // Assert
        _ = subject.ShouldNotBeNull();
        string result = subject;
        result.ShouldBe(provided);
    }

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        const string provided = Value;

        // Act
        Argument.Mode subject = provided;
        string result = subject;

        // Assert
        result.ShouldBe(provided);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        const string provided = Value;

        // Act
        Argument.Mode first = provided;
        Argument.Mode second = provided;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}