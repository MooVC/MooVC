namespace MooVC.Syntax.CSharp.Elements.SymbolTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        Symbol.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenFullQualificationThenQualifierIsIncluded()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["System", "Text"]));

        Symbol.Options options = Symbol.Options.Default
            .WithQualification(Symbol.Qualification.Full);

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("System.Text.Result");
    }

    [Test]
    public async Task GivenGlobalQualificationThenGlobalPrefixIsAdded()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create(qualifier: new Qualifier(["System", "Text"]));

        Symbol.Options options = Symbol.Options.Default
            .WithQualification(Symbol.Qualification.Global);

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("global::System.Text.Result");
    }

    [Test]
    public async Task GivenNullableThenSuffixIsApplied()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        subject.IsNullable = true;

        // Act
        string representation = subject.ToSnippet(Symbol.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("Result?");
    }
}