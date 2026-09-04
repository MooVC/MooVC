namespace MooVC.Syntax.CSharp.MonikerTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenValueThenStringIsReturned()
    {
        // Arrange
        Moniker subject = "Value";

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("Value");
    }
}