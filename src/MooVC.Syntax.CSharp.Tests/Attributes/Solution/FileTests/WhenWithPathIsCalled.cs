namespace MooVC.Syntax.CSharp.Attributes.Solution.FileTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithPathIsCalled
{
    [Fact]
    public void GivenPathThenReturnsUpdatedInstance()
    {
        // Arrange
        File original = FileTestsData.Create();
        Snippet updated = Snippet.From("src/other.cs");

        // Act
        File result = original.WithPath(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Path.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
    }
}