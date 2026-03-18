namespace MooVC.Syntax.CSharp.Members.AttributeExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members.AttributeTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstAttributeName = "Beta";
    private const string SecondAttributeName = "Alpha";

    [Test]
    [Arguments(true)]
    [Arguments(false)]
    public async Task GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Attribute> attributes = isDefault
            ? default
            : [];

        // Act
        var snippet = attributes.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(snippet).IsEqualTo(Snippet.Empty);
    }

    [Test]
    public async Task GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Attribute> attributes = [AttributeTestsData.Create()];
        Type.Options? options = default;

        // Act
        ArgumentNullException exception = await Assert.That(() => _ = attributes.ToSnippet(options!)).Throws<ArgumentNullException>();

        // Assert
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }

    [Test]
    public async Task GivenValuesThenAnOrderedSnippetIsReturned()
    {
        // Arrange
        Attribute first = AttributeTestsData.Create(name: FirstAttributeName);
        Attribute second = AttributeTestsData.Create(name: SecondAttributeName);

        ImmutableArray<Attribute> attributes = [first, second];

        const string expected = """
            [Alpha]
            [Beta]
            """;

        // Act
        var snippet = attributes.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(snippet.ToString()).IsEqualTo(expected);
    }
}