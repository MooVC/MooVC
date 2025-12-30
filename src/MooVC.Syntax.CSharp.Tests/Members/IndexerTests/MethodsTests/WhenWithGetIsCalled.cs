namespace MooVC.Syntax.CSharp.Members.IndexerTests.MethodsTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithGetIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var original = new Indexer.Methods
        {
            Set = Snippet.From("value"),
        };

        var get = Snippet.From("result");

        // Act
        Indexer.Methods result = original.WithGet(get);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Get.ShouldBe(get);
        result.Set.ShouldBe(original.Set);
        original.Get.ShouldBe(Snippet.Empty);
    }
}