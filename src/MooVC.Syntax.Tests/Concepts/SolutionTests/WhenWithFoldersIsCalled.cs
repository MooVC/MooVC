namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Linq;
using MooVC.Syntax.Attributes.Solution;

public sealed class WhenWithFoldersIsCalled
{
    [Test]
    public async Task GivenFoldersThenReturnsUpdatedInstance()
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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Folders).IsEqualTo(original.Folders.Concat([additional]));
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}