namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Data result = original.WithType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Value.ShouldBe(original.Value);
    }
}