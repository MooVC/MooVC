namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
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
        representation.ShouldContain("private set");
        representation.ShouldContain("get => value;");
    }
}