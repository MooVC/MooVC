namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Field subject = FieldTestsData.Create();
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenUndefinedFieldThenEmptyReturned()
    {
        // Arrange
        Field subject = Field.Undefined;

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEmpty();
    }

    [Test]
    public async Task GivenFieldWithDefaultThenSignatureIncludesAssignment()
    {
        // Arrange
        Field subject = FieldTestsData.Create(
            @default: Snippet.From("default"),
            isReadOnly: false,
            isStatic: true,
            name: FieldTestsData.DefaultName,
            scope: Scope.Public,
            type: SymbolTestsData.Create("Result"));

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo("public static Result Value = default;");
    }
}