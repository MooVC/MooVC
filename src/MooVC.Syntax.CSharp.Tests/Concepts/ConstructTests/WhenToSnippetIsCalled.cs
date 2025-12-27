namespace MooVC.Syntax.CSharp.Concepts.ConstructTests;

using System;
using MooVC.Syntax.CSharp;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var subject = new TestConstruct();

        // Act
        Func<Snippet> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenUndefinedThenReturnsEmptySnippet()
    {
        // Arrange
        var subject = new TestConstruct { IsUndefinedValue = true };

        // Act
        Snippet result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }
}