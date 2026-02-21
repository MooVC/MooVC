namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Data original = DataTestsData.Create();
        var updated = "Other";

        // Act
        Data result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Comment.ShouldBe(original.Comment);
        result.MimeType.ShouldBe(original.MimeType);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
    }
}