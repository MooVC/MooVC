namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System;
using MooVC.Syntax.CSharp;

public sealed class WhenToSnippetIsCalled
{
    private const string StaticKeyword = "static";

    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Class subject = ClassTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenStaticClassThenSignatureIncludesStaticKeyword()
    {
        // Arrange
        Class subject = ClassTestsData.Create(isStatic: true);

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldContain($"{StaticKeyword} class");
    }
}