namespace MooVC.Syntax.CSharp.PropertyTests.MethodsTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenAutoImplementedMembersThenStubIsReturned()
    {
        // Arrange
        var subject = new Property.Methods();

        // Act
        string representation = subject.ToSnippet(Property.Options.Default, Scope.Public);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("get; init;");
    }

    [Test]
    public async Task GivenReadOnlyLambdaThenGetterBodyIsReturned()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Setter
            {
                Mode = Property.Mode.ReadOnly,
            },
        };

        // Act
        string representation = subject.ToSnippet(Property.Options.Default, Scope.Public);

        // Assert
        _ = await Assert.That(representation).IsEqualTo("value;");
    }

    [Test]
    public async Task GivenScopedSetterThenScopeIsIncluded()
    {
        // Arrange
        var subject = new Property.Methods
        {
            Get = Snippet.From("value;"),
            Set = new Property.Setter
            {
                Behaviour = Snippet.From("_value = value;"),
                Scope = Scope.Private,
            },
        };

        // Act
        string representation = subject.ToSnippet(Property.Options.Default, Scope.Public);

        // Assert
        _ = await Assert.That(representation).Contains("private init");
        _ = await Assert.That(representation).Contains("get => value;");
    }
}