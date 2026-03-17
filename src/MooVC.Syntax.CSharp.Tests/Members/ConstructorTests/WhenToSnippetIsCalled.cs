namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public void GivenNullConstructThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Type? type = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(Type.Options.Default, type!));

        // Assert
        exception.ParamName.ShouldBe(nameof(type));
    }

    [Test]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Type type = ConstructorTestsData.CreateType();
        Type.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!, type));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Test]
    public void GivenUndefinedConstructorThenEmptyReturned()
    {
        // Arrange
        Constructor subject = Constructor.Undefined;
        Type type = ConstructorTestsData.CreateType();

        // Act
        string result = subject.ToSnippet(Type.Options.Default, type);

        // Assert
        result.ShouldBeEmpty();
    }

    [Test]
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

        // Act
        string representation = subject.ToSnippet(Type.Options.Default, type);

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