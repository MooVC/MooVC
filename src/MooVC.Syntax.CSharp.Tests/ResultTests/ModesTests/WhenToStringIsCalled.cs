namespace MooVC.Syntax.CSharp.ResultTests.ModesTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAsynchronousThenReturnsAsyncKeyword()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Asynchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("async");
    }

    [Test]
    public async Task GivenSynchronousThenReturnsEmpty()
    {
        // Arrange
        Result.Modes subject = Result.Modes.Synchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}