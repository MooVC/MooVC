namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = new Name("Other");

        // Act
        Metadata result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Value.ShouldBe(original.Value);
    }
}