namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenSingleLineBracesThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.SingleLineBraces));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("public string Perform(int value) { return value; }");
    }

    [Fact]
    public void GivenLambdaInlineThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("public string Perform(int value) => return value;");
    }

    [Fact]
    public void GivenBodyWhenSynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToSnippet(options);

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
        string representation = subject.ToSnippet(options);

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