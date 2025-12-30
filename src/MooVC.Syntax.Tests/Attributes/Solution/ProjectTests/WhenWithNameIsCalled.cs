namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Project original = ProjectTestsData.Create();
        var updated = Snippet.From("OtherName");

        // Act
        Project result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Path.ShouldBe(original.Path);
        result.Type.ShouldBe(original.Type);
    }
}