namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public void GivenScopedSetterThenScopeIsIncluded()
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
        representation.ShouldContain("private init");
        representation.ShouldContain("get => value;");
    }

    [Test]
    public void GivenReadOnlyLambdaThenGetterBodyIsReturned()
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
        representation.ShouldBe("value;");
    }

    [Test]
    public void GivenAutoImplementedMembersThenStubIsReturned()
    {
        // Arrange
        var subject = new Property.Methods();

        // Act
        string representation = subject.ToSnippet(Snippet.Options.Default, Scope.Public);

        // Assert
        representation.ShouldBe("get; init;");
    }
}