namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        Snippet updated = Snippet.From("Other");

        // Act
        Data result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.MimeType.ShouldBe(original.MimeType);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
        result.XmlSpace.ShouldBe(original.XmlSpace);
    }
}