namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenWithFoldersIsCalled
{
    [Fact]
    public void GivenFoldersThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder existing = SolutionTestsData.CreateFolder();

        var additional = new Folder
        {
            Name = new Folder.Path("/other/"),
        };

        Solution original = SolutionTestsData.Create(folder: existing);

        // Act
        Solution result = original.WithFolders(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Folders.ShouldBe(original.Folders.Concat([additional]));
        result.Configurations.ShouldBe(original.Configurations);
    }
}