namespace MooVC.Syntax.Attributes.Project.MetadataTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithValueIsCalled
{
    private const string UpdatedValue = "UpdatedValue";

    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Metadata original = MetadataTestsData.Create();
        var updated = Snippet.From(UpdatedValue);

        // Act
        Metadata result = original.WithValue(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Value.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Name.ShouldBe(original.Name);
    }
}