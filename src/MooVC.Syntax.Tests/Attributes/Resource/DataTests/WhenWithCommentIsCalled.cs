namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithCommentIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        Snippet updated = Snippet.From("Other");

        // Act
        Data result = original.WithComment(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Comment.ShouldBe(updated);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
        result.XmlSpace.ShouldBe(original.XmlSpace);
    }
}