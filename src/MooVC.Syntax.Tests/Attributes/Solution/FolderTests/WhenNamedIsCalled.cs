namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder original = FolderTestsData.Create();
        var updated = new Folder.Path("/Other/");

        // Act
        Folder result = original.Named(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(updated);
        _ = await Assert.That(result.Files).IsEqualTo(original.Files);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
        _ = await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}