namespace MooVC.Syntax.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorFromImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> _values = ["Alpha", "Beta"];

    [Test]
    public async Task GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> provided = default;

        // Act
        Snippet subject = provided;

        // Assert
        _ = await Assert.That(subject).IsNotNull();
        ImmutableArray<string> result = subject;
        _ = await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        ImmutableArray<string> provided = _values;

        // Act
        Snippet first = provided;
        Snippet second = provided;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenValuesThenRoundTripsSuccessfully()
    {
        // Arrange
        ImmutableArray<string> provided = _values;

        // Act
        Snippet subject = provided;
        ImmutableArray<string> result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(provided);
    }
}