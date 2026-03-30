namespace MooVC.Syntax.CSharp.ArgumentTests.ModeTests;

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
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(provided);
    }

    [Test]
    public async Task GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange & Act
        Argument.Mode first = Value;
        Argument.Mode second = Value;

        // Assert
        _ = await Assert.That(first).IsNotSameReferenceAs(second);
        _ = await Assert.That(first == second).IsTrue();
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange & Act
        Argument.Mode subject = Value;
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo(Value);
    }
}