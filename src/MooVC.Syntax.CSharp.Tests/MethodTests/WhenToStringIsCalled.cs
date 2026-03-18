namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedMethodThenEmptyReturned()
    {
        // Arrange
        Method subject = Method.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenEmptyBodyWhenSynchronousThenSignatureIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("public string Perform(int value);");
    }

    [Test]
    public async Task GivenEmptyBodyWhenAsynchronousThenSignatureIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData
            .Create()
            .Returns(result => result
                .As(typeof(Task))
                .WithMode(Result.Modality.Asynchronous));

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo("public async Task<string> Perform(int value);");
    }
}