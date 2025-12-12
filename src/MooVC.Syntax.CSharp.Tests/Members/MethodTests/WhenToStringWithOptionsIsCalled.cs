namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenToStringWithOptionsIsCalled
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
        string representation = subject.ToString(options);

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
        string representation = subject.ToString(options);

        // Assert
        representation.ShouldBe("public string Perform(int value) => return value;");
    }
}