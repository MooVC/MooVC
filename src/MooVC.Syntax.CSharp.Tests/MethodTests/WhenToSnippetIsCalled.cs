namespace MooVC.Syntax.CSharp.MethodTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenBodyWhenAsynchronousThenBlockIsRendered()
    {
        // Arrange
        Method subject = MethodTestsData
            .Create(body: Snippet.From("return await value;"))
            .Returns(result => result
                .As(typeof(Task))
                .WithMode(Result.Modes.Asynchronous));

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        string expected = """
            public async Task<string> Perform(int value)
            {
                return await value;
            }
            """;

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenBodyWhenSynchronousThenBlockIsRendered()
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

        _ = await Assert.That(representation).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenGenericConstraintsThenWhereClauseIsIncluded()
    {
        // Arrange
        var constraints = new Constraint
        {
            Nature = Natures.Class,
            New = New.Required,
        };

        var generic = new Generic
        {
            Name = "T",
            Constraints = [constraints],
        };

        var declaration = new Declaration
        {
            Name = "Perform",
            Arguments = [generic],
        };

        Method subject = MethodTestsData.Create(name: declaration, body: Snippet.Empty);

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        _ = await Assert.That(representation).Contains("Perform<T>");
        _ = await Assert.That(representation).Contains("where T : class, new()");
    }

    [Test]
    public async Task GivenStructConstraintThenWhereClauseIncludesGenericParameter()
    {
        // Arrange
        var constraints = new Constraint
        {
            Nature = Natures.Struct,
        };

        var generic = new Generic
        {
            Name = "T",
            Constraints = [constraints],
        };

        var declaration = new Declaration
        {
            Name = "Perform",
            Arguments = [generic],
        };

        Method subject = MethodTestsData.Create(name: declaration, body: Snippet.Empty);

        // Act
        string representation = subject.ToSnippet(Method.Options.Default);

        // Assert
        _ = await Assert.That(representation).Contains("where T : struct");
    }

    [Test]
    public async Task GivenLambdaInlineThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Method.Options options = Method.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.Options.Blocks.Styles.Lambda)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("public string Perform(int value) => return value;");
    }

    [Test]
    public async Task GivenSingleLineBracesThenBodyIsRenderedInline()
    {
        // Arrange
        Method subject = MethodTestsData.Create(body: Snippet.From("return value;"));

        Method.Options options = Method.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.Options.Blocks.Styles.SingleLine)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("public string Perform(int value) { return value; }");
    }
}