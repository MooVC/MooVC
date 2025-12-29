namespace MooVC.Syntax.CSharp.Attributes.Project.ImportTests;

public sealed class WhenWithProjectIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        var updated = Snippet.From("Updated");

        // Act
        Import result = original.WithProject(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Project.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
        result.Sdk.ShouldBe(original.Sdk);
    }
}