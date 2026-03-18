namespace MooVC.Syntax.CSharp.ArgumentTests.FormatterTests;

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
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(provided);
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
        _ = await Assert.That(result).IsEqualTo(provided);
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
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }
}