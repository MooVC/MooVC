namespace MooVC.Syntax.Attributes.Solution.FileTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        File original = FileTestsData.Create();
        var updated = Snippet.From("OtherId");

        // Act
        File result = original.WithId(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Id.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Path.ShouldBe(original.Path);
    }
}