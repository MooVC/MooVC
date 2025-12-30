namespace MooVC.Syntax.CSharp.Attributes.Solution.FolderTests;

using MooVC.Syntax.CSharp;

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Folder original = FolderTestsData.Create();
        Snippet updated = Snippet.From("OtherName");

        // Act
        Folder result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.Id.ShouldBe(original.Id);
        result.Files.ShouldBe(original.Files);
        result.Folders.ShouldBe(original.Folders);
        result.Items.ShouldBe(original.Items);
    }
}