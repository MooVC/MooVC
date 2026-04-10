namespace MooVC.Syntax.CSharp.SymbolTests;

using System.Collections.Immutable;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenAWrappedSymbolThenTheArgumentsAreApplied()
    {
        // Arrange
        Symbol argument = typeof(int);
        Symbol wrapper = typeof(ImmutableArray<>);

        Symbol wrapped = wrapper.WithArguments(symbol => symbol
            .IsNullable(argument.IsNullable)
            .Named(argument.Name));

        // Act
        var representation = wrapped.ToSnippet(Qualification.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("ImmutableArray<int>");
    }

    [Test]
    public async Task GivenNullableThenSuffixIsApplied()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        subject.IsNullable = true;

        // Act
        string representation = subject.ToSnippet(Qualification.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("Result?");
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Symbol subject = SymbolTestsData.Create();
        Qualification.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}