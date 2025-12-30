namespace MooVC.Syntax.CSharp.Attributes.Solution.FolderTests;

using System.Linq;
using MooVC.Syntax.CSharp;

public sealed class WhenWithFilesIsCalled
{
    [Fact]
    public void GivenFilesThenReturnsUpdatedInstance()
    {
        // Arrange
        File existing = FolderTestsData.CreateFile();
        File additional = FolderTestsData.CreateFile().WithName(Snippet.From("OtherFile"));
        Folder original = FolderTestsData.Create(file: existing);

        // Act
        Folder result = original.WithFiles(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Files.ShouldBe(original.Files.Concat([additional]));
        result.Folders.ShouldBe(original.Folders);
        result.Items.ShouldBe(original.Items);
        result.Id.ShouldBe(original.Id);
        result.Name.ShouldBe(original.Name);
    }
}