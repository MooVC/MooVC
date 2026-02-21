namespace MooVC.Syntax.CSharp.Members.AttributeExtensionsTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp.Members.AttributeTests;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    private const string FirstAttributeName = "Beta";
    private const string SecondAttributeName = "Alpha";

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GivenEmptyArrayThenEmptySnippetReturned(bool isDefault)
    {
        // Arrange
        ImmutableArray<Attribute> attributes = isDefault
            ? default
            : [];

        // Act
        var snippet = attributes.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ShouldBe(Snippet.Empty);
    }

    [Fact]
    public void GivenNullOptionsThenAnExceptionIsThrown()
    {
        // Arrange
        ImmutableArray<Attribute> attributes = [AttributeTestsData.Create()];
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = attributes.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenValuesThenAnOrderedSnippetIsReturned()
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
        var snippet = attributes.ToSnippet(Snippet.Options.Default);

        // Assert
        snippet.ToString().ShouldBe(expected);
    }
}