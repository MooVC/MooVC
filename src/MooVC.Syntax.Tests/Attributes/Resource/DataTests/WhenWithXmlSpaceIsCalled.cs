namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithXmlSpaceIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        Snippet updated = Snippet.From("Other");

        // Act
        Data result = original.WithXmlSpace(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.XmlSpace.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
    }
}