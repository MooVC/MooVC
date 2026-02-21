namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;

public sealed class WhenWithProjectsIsCalled
{
    [Fact]
    public void GivenProjectsThenReturnsUpdatedInstance()
    {
        // Arrange
        Project existing = FolderTestsData.CreateProject();
        Project additional = FolderTestsData.CreateProject().Named(new Project.Name("OtherProject"));
        Folder original = FolderTestsData.Create(project: existing);

        // Act
        Folder result = original.WithProjects(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Projects.ShouldBe(original.Projects.Concat([additional]));
        result.Files.ShouldBe(original.Files);
        result.Items.ShouldBe(original.Items);
        result.Name.ShouldBe(original.Name);
    }
}