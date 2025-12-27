namespace MooVC.Syntax.CSharp.Members.ResultTests.ModalityTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenAsynchronousThenReturnsAsyncKeyword()
    {
        // Arrange
        Result.Modality subject = Result.Modality.Asynchronous;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("async");
    }

    [Fact]
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