namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenEqualityOperatorModesStringIsCalled
{
    [Test]
    public async Task GivenEqualValueThenReturnsTrue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;

        // Act
        bool result = subject == "async";

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}