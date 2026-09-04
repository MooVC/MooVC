namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenEqualsModesIsCalled
{
    [Test]
    public async Task GivenEquivalentModesThenReturnsTrue()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;
        Result.Modes other = Result.Modes.Asynchronous;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }
}