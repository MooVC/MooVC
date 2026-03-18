namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.ParameterTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullConstructThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Type? type = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(Type.Options.Default, type!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(type));
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Type type = ConstructorTestsData.CreateType();
        Type.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!, type);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenUndefinedConstructorThenEmptyReturned()
    {
        // Arrange
        Constructor subject = Constructor.Undefined;
        Type type = ConstructorTestsData.CreateType();

        // Act
        string result = subject.ToSnippet(Type.Options.Default, type);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenBodyThenBlockIsRendered()
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

        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}