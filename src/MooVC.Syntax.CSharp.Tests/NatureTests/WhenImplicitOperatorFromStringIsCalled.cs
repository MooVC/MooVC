namespace MooVC.Syntax.CSharp.NatureTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenNonEmptyValueThenCreatesNature()
    {
        // Arrange
        const string Value = "unmanaged";

        // Act
        Nature result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenEmptyValueThenCreatesNature()
    {
        // Arrange
        const string Value = "";

        // Act
        Nature result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }
}