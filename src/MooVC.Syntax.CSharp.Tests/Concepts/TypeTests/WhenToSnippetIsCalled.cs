namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using System;
using MooVC.Syntax.CSharp;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var subject = new TestType();

        // Act
        Func<Snippet> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenUndefinedThenReturnsEmptySnippet()
    {
        // Arrange
        var subject = new TestType { IsUndefinedValue = true };

        // Act
        var result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }
}