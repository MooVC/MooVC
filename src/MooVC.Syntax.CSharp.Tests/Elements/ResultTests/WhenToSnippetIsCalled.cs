namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Result subject = Result.Task;
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }
}