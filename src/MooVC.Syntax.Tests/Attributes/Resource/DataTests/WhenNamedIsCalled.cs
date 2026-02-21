namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = "Other";

        // Act
        Data result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.MimeType.ShouldBe(original.MimeType);
        result.Type.ShouldBe(original.Type);
        result.Value.ShouldBe(original.Value);
    }
}