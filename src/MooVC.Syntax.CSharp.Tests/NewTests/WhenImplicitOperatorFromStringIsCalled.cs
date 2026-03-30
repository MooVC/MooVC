namespace MooVC.Syntax.CSharp.NewTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenEmptyValueThenCreatesNew()
    {
        // Arrange
        const string Value = "";

        // Act
        New result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }

    [Test]
    public async Task GivenNewConstraintThenCreatesNew()
    {
        // Arrange
        const string Value = "new()";

        // Act
        New result = Value;

        // Assert
        _ = await Assert.That(result.ToString()).IsEqualTo(Value);
    }
}