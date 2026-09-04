namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    [Test]
    public async Task GivenStringValueThenReturnsMode()
    {
        // Arrange
        string subject = "async";

        // Act
        Result.Modes mode = subject;

        // Assert
        _ = await Assert.That(mode).IsEqualTo(Result.Modes.Asynchronous);
    }
}