namespace MooVC.Syntax.CSharp.Attributes.Solution.FolderTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithIdIsCalled
{
    [Fact]
    public void GivenIdThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder original = FolderTestsData.Create();
        Snippet updated = Snippet.From("OtherId");

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