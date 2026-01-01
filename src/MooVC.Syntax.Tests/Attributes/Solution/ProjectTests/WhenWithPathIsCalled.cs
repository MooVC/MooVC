namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithPathIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create();
        var updated = Snippet.From("src/Other.csproj");

        // Act
        Project result = original.WithPath(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Path.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(original.Type);
    }
}