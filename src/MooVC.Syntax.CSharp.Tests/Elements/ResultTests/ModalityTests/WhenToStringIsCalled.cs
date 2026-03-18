namespace MooVC.Syntax.CSharp.Elements.ResultTests.ModalityTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenAsynchronousThenReturnsAsyncKeyword()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("async");
    }

    [Test]
    public async Task GivenSynchronousThenReturnsEmpty()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Synchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}