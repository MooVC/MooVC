namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        Symbol.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenFullQualificationThenQualifierIsIncluded()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["System", "Text"]));

        Symbol.Options options = new Symbol.Options()
            .WithQualification(Symbol.Qualification.Full);

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("System.Text.Result");
    }

    [Fact]
    public void GivenGlobalQualificationThenGlobalPrefixIsAdded()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["System", "Text"]));

        Symbol.Options options = new Symbol.Options()
            .WithQualification(Symbol.Qualification.Global);

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        representation.ShouldBe("global::System.Text.Result");
    }

    [Fact]
    public void GivenNullableThenSuffixIsApplied()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        subject.IsNullable = true;

        // Act
        string representation = subject.ToSnippet(Symbol.Options.Default);

        // Assert
        representation.ShouldBe("Result?");
    }
}