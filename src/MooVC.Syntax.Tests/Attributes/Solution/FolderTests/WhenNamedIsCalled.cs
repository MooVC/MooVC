namespace MooVC.Syntax.Attributes.Solution.FolderTests;

public sealed class WhenNamedIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder original = FolderTestsData.Create();
        var updated = new Folder.Path("/Other/");

        // Act
        Folder result = original.Named(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Files.ShouldBe(original.Files);
        result.Items.ShouldBe(original.Items);
        result.Projects.ShouldBe(original.Projects);
    }
}