namespace MooVC.Syntax.CSharp.Elements.ArgumentTests.ModeTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsUnderlyingValue()
    {
        // Arrange
        Argument.Mode subject = Argument.Mode.Out;

        // Act
        string result = subject;

        // Assert
        await Assert.That(result).IsEqualTo("out");
    }
}