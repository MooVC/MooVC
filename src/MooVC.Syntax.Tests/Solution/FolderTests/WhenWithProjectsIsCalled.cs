namespace MooVC.Syntax.Solution.FolderTests;

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
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Projects).IsEquivalentTo([.. original.Projects, additional]);
        _ = await Assert.That(result.Files).IsEqualTo(original.Files);
        _ = await Assert.That(result.Items).IsEqualTo(original.Items);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}