namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.FormatterTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Value = "{0} = {1}";

    [Test]
    public async Task GivenDefaultThenInstanceIsCreated()
    {
        // Arrange
        string? provided = default;

        // Act
        Argument.Formatter subject = provided!;

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
        Argument.Formatter subject = provided;
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
        Argument.Formatter first = provided;
        Argument.Formatter second = provided;

        // Assert
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
        await Assert.That((first == second)).IsTrue();
        await Assert.That(first.Equals(second)).IsTrue();
    }
}