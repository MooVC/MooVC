namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create();
        var updated = Snippet.From("Other");

        // Act
        Project result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
    }
}