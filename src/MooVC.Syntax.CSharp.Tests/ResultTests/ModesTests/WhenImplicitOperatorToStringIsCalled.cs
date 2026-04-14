namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenImplicitOperatorToStringIsCalled
{
    [Test]
    public async Task GivenModeThenReturnsStringValue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;

        // Act
        string mode = subject;

        // Assert
        _ = await Assert.That(mode).IsEqualTo("async");
    }
}