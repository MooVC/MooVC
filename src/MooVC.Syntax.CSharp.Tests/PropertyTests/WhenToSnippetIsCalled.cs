namespace MooVC.Syntax.CSharp.PropertyTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    [Arguments(false, "private set")]
    [Arguments(true, "private init")]
    public async Task GivenAutoPropertyWithPrivateSetterThenScopeIsRendered(bool useInit, string setter)
    {
        // Arrange
        Property subject = Property.Undefined
            .Named("Value")
            .OfType(typeof(string))
            .WithBehaviours(behaviours => behaviours.WithSet(accessor => accessor
                .WithMode(useInit ? Property.Methods.Setter.Modes.Init : Property.Methods.Setter.Modes.Set)
                .WithScope(Scopes.Private)));

        // Act
        string representation = subject.ToSnippet(Property.Options.Default);

        // Assert
        _ = await Assert.That(representation).IsEqualTo($"public string Value {{ get; {setter}; }}");
    }

    [Test]
    public async Task GivenGetOnlyPropertyWhenInlineIsLambdaThenBodyIsRendered()
    {
        // Arrange
        var behaviours = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new() { Mode = Property.Methods.Setter.Modes.ReadOnly },
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