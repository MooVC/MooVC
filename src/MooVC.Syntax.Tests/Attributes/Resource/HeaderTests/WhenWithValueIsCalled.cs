namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Header original = HeaderTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Header result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
    }
}