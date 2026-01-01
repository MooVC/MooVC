namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;
using MooVC.Syntax.Elements;

public sealed class WhenWithFoldersIsCalled
{
    [Fact]
    public void GivenFoldersThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder existing = FolderTestsData.CreateChildFolder();
        Folder additional = FolderTestsData.CreateChildFolder().Named(Snippet.From("OtherFolder"));
        Folder original = FolderTestsData.Create(folder: existing);

        // Act
        Folder result = original.WithFolders(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Folders.ShouldBe(original.Folders.Concat([additional]));
        result.Files.ShouldBe(original.Files);
        result.Items.ShouldBe(original.Items);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
    }
}