namespace MooVC.Syntax.CSharp.NaturesTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenEmptyValueThenCreatesNatures()
    {
        // Arrange
        const string Value = "";

        // Act
        Natures result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenNonEmptyValueThenCreatesNatures()
    {
        // Arrange
        const string Value = "unmanaged";

        // Act
        Natures result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }
}