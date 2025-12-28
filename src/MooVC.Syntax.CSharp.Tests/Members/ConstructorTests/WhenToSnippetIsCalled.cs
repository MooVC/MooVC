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
        Type? type = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(Snippet.Options.Default, type!));

        // Assert
        exception.ParamName.ShouldBe(nameof(type));
    }

    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Type type = ConstructorTestsData.CreateType();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!, type));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenUndefinedConstructorThenEmptyReturned()
    {
        // Arrange
        Constructor subject = Constructor.Undefined;
        Type type = ConstructorTestsData.CreateType();

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default, type);

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

        Type type = ConstructorTestsData.CreateType();

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block.WithInline(Snippet.BlockOptions.InlineStyle.MultiLineBraces));

        // Act
        string representation = subject.ToSnippet(options, type);

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