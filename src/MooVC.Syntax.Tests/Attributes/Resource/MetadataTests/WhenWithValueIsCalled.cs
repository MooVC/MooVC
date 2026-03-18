namespace MooVC.Syntax.Attributes.Resource.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Test]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Metadata result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
    }
}