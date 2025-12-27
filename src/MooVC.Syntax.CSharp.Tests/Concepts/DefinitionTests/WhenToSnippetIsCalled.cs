namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using System;
using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToSnippetIsCalled
{
    private const string NamespaceValue = "Demo.App";
    private const string TypeName = "Widget";
    private const string UsingQualifier = "System";

    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var subject = new Definition<Class>();

        // Act
        Func<Snippet> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenEmptyDefinitionThenReturnsEmptyString()
    {
        // Arrange
        var subject = Definition<Class>.Empty;

        // Act
        string result = subject.ToSnippet(Options.Default);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenUndefinedConstructThenReturnsEmptySnippet()
    {
        // Arrange
        var subject = new Definition<Class>
        {
            Construct = Class.Undefined,
        };

        // Act
        string result = subject.ToSnippet(Options.Default);

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenBlockNamespaceThenBuildsNamespaceBlock()
    {
        // Arrange
        var subject = CreateDefinition();
        Options options = Options.Default.WithNamespace(Qualifier.Options.Block);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldContain(NamespaceValue);
        result.ShouldContain("{");
        result.ShouldContain($"using {UsingQualifier};");
    }

    [Fact]
    public void GivenFileNamespaceThenReturnsFileScopedDefinition()
    {
        // Arrange
        var subject = CreateDefinition();
        Options options = Options.Default.WithNamespace(Qualifier.Options.File);

        // Act
        string result = subject.ToSnippet(options);

        // Assert
        result.ShouldContain(NamespaceValue);
        result.ShouldContain(TypeName);
    }

    private static Definition<Class> CreateDefinition()
    {
        return new Definition<Class>
        {
            Namespace = NamespaceValue,
            Usings =
            [
                new Directive { Qualifier = UsingQualifier },
            ],
            Construct = new Class
            {
                Name = new Declaration { Name = new Identifier(TypeName) },
            },
        };
    }
}