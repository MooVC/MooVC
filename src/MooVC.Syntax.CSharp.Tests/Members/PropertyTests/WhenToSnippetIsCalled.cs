namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }

    [Fact]
    public void GivenGetOnlyPropertyWhenInlineIsLambdaThenBodyIsRendered()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = "value;",
            Set = new Property.Setter { Mode = Property.Mode.ReadOnly },
        };

        Property subject = PropertyTestsData.Create(behaviours: behaviours);

        Property.Options options = Property.Options.Default
            .WithSnippets(snippets => snippets
                .WithBlock(block => block
                    .WithInline(Snippet.BlockOptions.InlineStyle.Lambda)));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        const string Expected = "public string Value => value;";

        representation.ShouldBe(Expected);
    }
}