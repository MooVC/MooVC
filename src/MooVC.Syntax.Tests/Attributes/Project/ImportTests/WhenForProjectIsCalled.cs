namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenForProjectIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From("Updated");

        // Act
        Import result = original.ForProject(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Project.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
        result.Sdk.ShouldBe(original.Sdk);
    }
}