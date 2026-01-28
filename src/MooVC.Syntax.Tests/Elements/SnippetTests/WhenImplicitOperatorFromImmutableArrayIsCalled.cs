namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorFromImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> values = ["Alpha", "Beta"];

    [Fact]
    public void GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> provided = default;

        // Act
        Snippet subject = provided;

        // Assert
        _ = subject.ShouldNotBeNull();
        ImmutableArray<string> result = subject;
        result.IsEmpty.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenRoundTripsSuccessfully()
    {
        // Arrange
        ImmutableArray<string> provided = values;

        // Act
        Snippet subject = provided;
        ImmutableArray<string> result = subject;

        // Assert
        result.ShouldBe(provided);
    }

    [Fact]
    public void GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        ImmutableArray<string> provided = values;

        // Act
        Snippet first = provided;
        Snippet second = provided;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}