namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenGetOnlyPropertyWhenInlineIsLambdaThenBodyIsRendered()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Methods.Setter { Mode = Property.Methods.Setter.Modes.ReadOnly },
        };

        Property subject = PropertyTestsData.Create(behaviours: behaviours);

        // Act
        string representation = subject.ToSnippet(Property.Options.Default);

        // Assert
        const string Expected = "public string Value => value;";

        _ = await Assert.That(representation).IsEqualTo(Expected);
    }

    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Property.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}