namespace MooVC.Syntax.CSharp.Members.IndexerTests;

public sealed class WhenToStringWithOptionsIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToString(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }
}
