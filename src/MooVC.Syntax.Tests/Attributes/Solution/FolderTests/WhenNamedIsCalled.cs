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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(updated);
        await Assert.That(result.Files).IsEqualTo(original.Files);
        await Assert.That(result.Items).IsEqualTo(original.Items);
        await Assert.That(result.Projects).IsEqualTo(original.Projects);
    }
}