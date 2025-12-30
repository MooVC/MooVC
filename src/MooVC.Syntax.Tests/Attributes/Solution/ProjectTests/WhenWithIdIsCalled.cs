namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create();
        var updated = Snippet.From("OtherId");

        // Act
        Project result = original.WithId(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Id.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
    }
}