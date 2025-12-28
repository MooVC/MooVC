namespace MooVC.Syntax.CSharp.Members.PropertyTests.MethodsTests;

using MooVC.Syntax.CSharp.Elements;

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

    [Fact]
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

        Snippet.Options options = Snippet.Options.Default
            .WithBlock(block => block
                .WithInline(Snippet.BlockOptions.InlineStyle.Lambda));

        // Act
        string representation = subject.ToSnippet(options, Scope.Public);

        // Assert
        representation.ShouldBe("value;");
    }

    [Fact]
    public void GivenAutoImplementedMembersThenStubIsReturned()
    {
        // Arrange
        var subject = new Property.Methods();

        // Act
        string representation = subject.ToSnippet(Snippet.Options.Default, Scope.Public);

        // Assert
        representation.ShouldBe("get; set;");
    }
}