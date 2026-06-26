namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenValueThenMonikerEqualsString()
    {
        // Arrange
        const string value = "Value";

        // Act
        Moniker result = value;

        // Assert
        _ = await Assert.That(result == value).IsTrue();
    }
}