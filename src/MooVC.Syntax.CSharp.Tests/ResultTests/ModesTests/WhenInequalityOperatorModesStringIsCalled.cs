namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenInequalityOperatorModesStringIsCalled
{
    [Test]
    public async Task GivenDifferentValueThenReturnsTrue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;

        // Act
        bool result = subject != string.Empty;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}