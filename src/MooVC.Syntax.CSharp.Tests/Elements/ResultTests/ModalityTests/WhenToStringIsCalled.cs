namespace MooVC.Syntax.CSharp.Elements.ResultTests.ModalityTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenAsynchronousThenReturnsAsyncKeyword()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("async");
    }

    [Test]
    public void GivenSynchronousThenReturnsEmpty()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Synchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }
}