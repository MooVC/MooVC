namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;

public sealed class WhenWithFilesIsCalled
{
    [Test]
    public async Task GivenFilesThenReturnsUpdatedInstance()
    {
        // Arrange
        File existing = FolderTestsData.CreateFile();
        var additional = new File("src/other.cs");
        Folder original = FolderTestsData.Create(file: existing);

        // Act
        Folder result = original.WithFiles(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Files).IsEqualTo(original.Files.Concat([additional]));
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}