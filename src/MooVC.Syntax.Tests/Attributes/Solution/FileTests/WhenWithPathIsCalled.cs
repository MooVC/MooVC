namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax;
using MooVC.Syntax.Elements;

public sealed class WhenWithPathIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        File original = FileTestsData.Create();
        var updated = Snippet.From("src/other.cs");

        // Act
        File result = original.WithPath(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Path.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
    }
}