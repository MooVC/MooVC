namespace MooVC.Syntax.SolutionTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Folders).IsEquivalentTo([.. original.Folders, additional]);
        _ = await Assert.That(result.Configurations).IsEqualTo(original.Configurations);
    }
}