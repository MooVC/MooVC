namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenEqualityOperatorModesModesIsCalled
{
    [Test]
    public async Task GivenEqualModesThenReturnsTrue()
    {
        // Arrange
        Result.Modes left = Result.Modes.Asynchronous;
        Result.Modes right = Result.Modes.Asynchronous;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}