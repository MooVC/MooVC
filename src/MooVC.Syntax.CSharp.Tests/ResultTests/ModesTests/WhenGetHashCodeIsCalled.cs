namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentModesThenReturnsSameValue()
    {
        // Arrange
        Result.Modes first = Result.Modes.Asynchronous;
        Result.Modes second = Result.Modes.Asynchronous;

        // Act
        int firstHashCode = first.GetHashCode();
        int secondHashCode = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHashCode).IsEqualTo(secondHashCode);
    }
}