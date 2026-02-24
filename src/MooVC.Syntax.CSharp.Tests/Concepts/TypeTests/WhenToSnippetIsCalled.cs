namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using MooVC.Syntax.Elements;

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
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        result.ShouldBe(Snippet.Empty);
    }
}