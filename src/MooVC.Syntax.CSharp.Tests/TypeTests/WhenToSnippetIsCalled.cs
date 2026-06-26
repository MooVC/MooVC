namespace MooVC.Syntax.CSharp.TypeTests;

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
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenUndefinedThenReturnsEmptySnippet()
    {
        // Arrange
        var subject = new TestType { IsUndefinedValue = true };

        // Act
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(Snippet.Empty);
    }
}