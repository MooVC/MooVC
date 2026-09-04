namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenInequalityOperatorModesModesIsCalled
{
    [Test]
    public async Task GivenDifferentModesThenReturnsTrue()
    {
        // Arrange
        Result.Modes left = Result.Modes.Asynchronous;
        Result.Modes right = Result.Modes.Synchronous;

        // Act
        bool result = left != right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}