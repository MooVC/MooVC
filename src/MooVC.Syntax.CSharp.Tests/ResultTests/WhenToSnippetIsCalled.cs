namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenNullOptionsThenThrows()
    {
        // Arrange
        Result subject = Result.Task;
        Snippet.Options? options = default;

        // Act
        Func<Snippet> act = () => _ = subject.ToSnippet(options!);

        // Assert
        ArgumentNullException exception = await Assert.That(act).Throws<ArgumentNullException>().And.IsNotNull();
        _ = await Assert.That(exception.ParamName).IsEqualTo(nameof(options));
    }
}