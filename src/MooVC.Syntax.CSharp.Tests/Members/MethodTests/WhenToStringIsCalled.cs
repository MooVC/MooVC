namespace MooVC.Syntax.CSharp.Members.MethodTests;

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

    [Fact]
    public void GivenBodyWhenSynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options);

        // Assert
        string expected = """
            public string Perform(int value)
            {
                return value;
            }
            """;

        representation.ShouldBe(expected);
    }

    [Fact]
    public void GivenBodyWhenAsynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData
            .Create(body: Snippet.From("return await value;"))
            .WithResult(result => result
                .As(typeof(Task))
                .WithMode(Result.Modality.Asynchronous));

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToString(options);

        // Assert
        string expected = """
            public async Task<string> Perform(int value)
            {
                return await value;
            }
            """;

        representation.ShouldBe(expected);
    }
}