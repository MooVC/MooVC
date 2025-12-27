namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Members.SymbolTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Field subject = FieldTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenUndefinedFieldThenEmptyReturned()
    {
        // Arrange
        Field subject = Field.Undefined;

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenFieldWithDefaultThenSignatureIncludesAssignment()
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
        result.ShouldBe("public static Result Value = default;");
    }
}