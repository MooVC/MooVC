namespace MooVC.Syntax.CSharp.Concepts.TypeTests;

using MooVC.Syntax.Elements;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        var subject = new TestType();

        // Act
        Func<Snippet> action = () => subject.ToSnippet(options: default);

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenUndefinedThenReturnsEmptySnippet()
    {
        // Arrange
        var subject = new TestType { IsUndefinedValue = true };

        // Act
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        await Assert.That(result).IsEqualTo(Snippet.Empty);
    }
}