namespace MooVC.Syntax.CSharp.Members.MethodTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public void GivenSingleLineBracesThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Method.Options options = Method.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(inline => inline.WithMethods(Snippet.BlockOptions.InlineStyle.SingleLineBraces))));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("public string Perform(int value) { return value; }");
    }

    [Test]
    public void GivenLambdaInlineThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Method.Options options = Method.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(inline => inline.WithMethods(Snippet.BlockOptions.InlineStyle.Lambda))));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("public string Perform(int value) => return value;");
    }

    [Test]
    public void GivenBodyWhenSynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        string expected = """
            public string Perform(int value)
            {
                return value;
            }
            """;

        representation.ShouldBe(expected);
    }

    [Test]
    public void GivenBodyWhenAsynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData
            .Create(body: Snippet.From("return await value;"))
            .Returns(result => result
                .As(typeof(Task))
                .WithMode(Result.Modality.Asynchronous));

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        string expected = """
            public async Task<string> Perform(int value)
            {
                return await value;
            }
            """;

        representation.ShouldBe(expected);
    }

    [Test]
    public void GivenGenericConstraintsThenWhereClauseIsIncluded()
    {
        // Arrange
        var constraints = new Constraint
        {
            Nature = Nature.Class,
            New = New.Required,
        };

        var generic = new Parameter
        {
            Name = "T",
            Constraints = [constraints],
        };

        var declaration = new Declaration
        {
            Name = "Perform",
            Parameters = [generic],
        };

        Method subject = MethodTestsData.Create(name: declaration, body: Snippet.Empty);

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        representation.ShouldContain("Perform<T>");
        representation.ShouldContain("where class, new()");
    }
}