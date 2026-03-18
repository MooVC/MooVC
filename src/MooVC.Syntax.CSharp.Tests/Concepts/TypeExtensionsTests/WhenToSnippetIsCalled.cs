namespace MooVC.Syntax.CSharp.Concepts.TypeExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Generics;
using MooVC.Syntax.CSharp.Operators;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Type> types = isDefault
            ? default
            : [];

        // Act
        var snippet = types.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        ImmutableArray<Type> types = [OperatorsTestsData.Create("Alpha")];
        Type.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = types.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenOrderedSnippetReturned()
    {
        // Arrange
        ImmutableArray<Type> types =
        [
            OperatorsTestsData.Create("Gamma"),
            OperatorsTestsData.Create("Alpha"),
            OperatorsTestsData.Create("Beta"),
        ];

        const string expected = """
            Alpha

            Beta

            Gamma
            """;

        // Act
        var snippet = types.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}