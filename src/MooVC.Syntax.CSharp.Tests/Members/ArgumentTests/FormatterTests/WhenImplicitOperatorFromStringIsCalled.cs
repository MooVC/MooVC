namespace MooVC.Syntax.CSharp.Members.ArgumentTests.FormatterTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "{0} = {1}";

    [Fact]
    public void GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        string? provided = default;

        // Act
        Argument.Formatter subject = provided!;

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
        Argument.Formatter subject = provided;
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
        Argument.Formatter first = provided;
        Argument.Formatter second = provided;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}
