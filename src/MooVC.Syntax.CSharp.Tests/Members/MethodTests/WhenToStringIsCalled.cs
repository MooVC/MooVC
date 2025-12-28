namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedMethodThenEmptyReturned()
    {
        // Arrange
        Method subject = Method.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenEmptyBodyWhenSynchronousThenSignatureIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("public string Perform(int value);");
    }

    [Fact]
    public void GivenEmptyBodyWhenAsynchronousThenSignatureIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData
            .Create()
            .WithResult(result => result
                .As(typeof(Task))
                .WithMode(Result.Modality.Asynchronous));

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("public async Task<string> Perform(int value);");
    }
}