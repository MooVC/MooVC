namespace MooVC.Syntax.Attributes.Solution.FolderTests;

using System.Linq;

public sealed class WhenWithProjectsIsCalled
{
    [Test]
    public async Task GivenProjectsThenReturnsUpdatedInstance()
    {
        // Arrange
        Project existing = FolderTestsData.CreateProject();
        Project additional = FolderTestsData.CreateProject().Named(new Project.Name("OtherProject"));
        Folder original = FolderTestsData.Create(project: existing);

        // Act
        Folder result = original.WithProjects(additional);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Projects).IsEqualTo(original.Projects.Concat([additional]));
        await Assert.That(result.Files).IsEqualTo(original.Files);
        await Assert.That(result.Items).IsEqualTo(original.Items);
        await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}