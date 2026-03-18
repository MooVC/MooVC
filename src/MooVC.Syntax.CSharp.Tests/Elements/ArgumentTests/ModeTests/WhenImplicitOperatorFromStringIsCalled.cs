namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "in";

    [Test]
    public async Task GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        string? provided = default;

        // Act
        Argument.Mode subject = provided!;

        // Assert
        _ = await Assert.That(subject).IsNotNull();
        string result = subject;
        await Assert.That(result).IsEqualTo(provided);
    }

    [Test]
    public async Task GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        const string provided = Value;

        // Act
        Argument.Mode subject = provided;
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo(provided);
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        const string provided = Value;

        // Act
        Argument.Mode first = provided;
        Argument.Mode second = provided;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}