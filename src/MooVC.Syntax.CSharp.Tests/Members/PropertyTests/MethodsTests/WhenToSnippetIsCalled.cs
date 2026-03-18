namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
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
        string representation = subject.ToSnippet(Snippet.Options.Default, Scope.Public);

        // Assert
        await Assert.That(representation).Contains("private init");
        await Assert.That(representation).Contains("get => value;");
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
        string representation = subject.ToSnippet(Snippet.Options.Default, Scope.Public);

        // Assert
        await Assert.That(representation).IsEqualTo("value;");
    }

    [Test]
    public async Task GivenAutoImplementedMembersThenStubIsReturned()
    {
        // Arrange
        var subject = new Property.Methods();

        // Act
        string representation = subject.ToSnippet(Snippet.Options.Default, Scope.Public);

        // Assert
        await Assert.That(representation).IsEqualTo("get; init;");
    }
}