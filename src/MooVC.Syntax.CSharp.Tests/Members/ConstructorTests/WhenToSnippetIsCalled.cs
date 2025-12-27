namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members.ParameterTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullConstructThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Construct? construct = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(construct!, Snippet.Options.Default));

        // Assert
        exception.ParamName.ShouldBe(nameof(construct));
    }

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Construct construct = ConstructorTestsData.CreateConstruct();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(construct, options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenUndefinedConstructorThenEmptyReturned()
    {
        // Arrange
        Constructor subject = Constructor.Undefined;
        Construct construct = ConstructorTestsData.CreateConstruct();

        // Act
        string result = subject.ToSnippet(construct, Snippet.Options.Default);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenBodyThenBlockIsRendered()
    {
        // Arrange
        Parameter[] parameters =
        [
            ParameterTestsData.Create(),
        ];

        Constructor subject = ConstructorTestsData.Create(
            body: Snippet.From("Initialize();"),
            parameters: [.. parameters]);

        Construct construct = ConstructorTestsData.CreateConstruct();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToSnippet(construct, options);

        // Assert
        string expected = """
            public Widget(Version value)
            {
                Initialize();
            }
            """;

        representation.ShouldBe(expected);
    }
}