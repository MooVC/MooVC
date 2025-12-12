namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

public sealed class WhenWithSetIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Indexer.Methods
        {
            Get = Snippet.From("value"),
        };

        var set = Snippet.From("result");

        // Act
        Indexer.Methods result = original.WithSet(set);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Get.ShouldBe(original.Get);
        result.Set.ShouldBe(set);
        original.Set.ShouldBe(Snippet.Empty);
    }
}