namespace MooVC.Syntax.CSharp.ArgumentTests.ModesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Modes subject = Argument.Modes.Out;

        // Act
        string result = subject;

        // Assert
        _ = await Assert.That(result).IsEqualTo("out");
    }
}