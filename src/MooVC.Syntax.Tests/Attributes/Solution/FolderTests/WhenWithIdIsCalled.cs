namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using MooVC.Syntax.Elements;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder original = FolderTestsData.Create();
        var updated = Snippet.From("OtherId");

        // Act
        Folder result = original.WithId(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Id.ShouldBe(updated);
        result.Name.ShouldBe(original.Name);
        result.Files.ShouldBe(original.Files);
        result.Folders.ShouldBe(original.Folders);
        result.Items.ShouldBe(original.Items);
    }
}