namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;

public sealed class WhenWithFilesIsCalled
{
    [Fact]
    public void GivenFilesThenReturnsUpdatedInstance()
    {
        // Arrange
        File existing = FolderTestsData.CreateFile();
        var additional = new File("src/other.cs");
        Folder original = FolderTestsData.Create(file: existing);

        // Act
        Folder result = original.WithFiles(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Files.ShouldBe(original.Files.Concat([additional]));
        result.Items.ShouldBe(original.Items);
        result.Name.ShouldBe(original.Name);
        result.Projects.ShouldBe(original.Projects);
    }
}