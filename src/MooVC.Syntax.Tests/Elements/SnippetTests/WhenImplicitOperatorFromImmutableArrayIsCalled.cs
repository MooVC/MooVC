namespace MooVC.Syntax.Elements.SnippetTests;

using System.Collections.Immutable;

public sealed class WhenImplicitOperatorFromImmutableArrayIsCalled
{
    private static readonly ImmutableArray<string> values = ["Alpha", "Beta"];

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
        await Assert.That(result.IsEmpty).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenRoundTripsSuccessfully()
    {
        // Arrange
        ImmutableArray<string> provided = values;

        // Act
        Snippet subject = provided;
        ImmutableArray<string> result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(provided);
    }

    [Test]
    public async Task GivenSameArrayTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        ImmutableArray<string> provided = values;

        // Act
        Snippet first = provided;
        Snippet second = provided;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}