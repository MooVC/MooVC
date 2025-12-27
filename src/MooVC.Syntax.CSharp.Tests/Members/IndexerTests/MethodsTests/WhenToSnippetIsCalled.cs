namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenToSnippetIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        var subject = new Indexer.Methods
        {
            Get = Snippet.From("get => value"),
        };

        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToSnippet(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }
}