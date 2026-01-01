namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithMimeTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Data result = original.WithMimeType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.MimeType.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
    }
}