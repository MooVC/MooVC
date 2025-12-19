namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Snippet.Options? options = default;

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
            Get = Snippet.From("value;"),
            Set = new Property.Setter { Mode = Property.Mode.ReadOnly },
        };

        Property subject = PropertyTestsData.Create(behaviours: behaviours);

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
            .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));

        // Act
        string representation = subject.ToSnippet(options);

        // Assert
        const string Expected = "public string Value => value;";

        representation.ShouldBe(Expected);
    }
}