namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenSolutionIsUndefined()
    {
        // Act
        var subject = new Solution();

        // Assert
        _ = await Assert.That(subject.Configurations).IsEqualTo(Configurations.Default);
        _ = await Assert.That(subject.Files).IsEmpty();
        _ = await Assert.That(subject.Folders).IsEmpty();
        _ = await Assert.That(subject.Items).IsEmpty();
        _ = await Assert.That(subject.Projects).IsEmpty();
        _ = await Assert.That(subject.Properties).IsEmpty();
        _ = await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Configurations configurations = Configurations.Default;
        File file = SolutionTestsData.CreateFile();
        Folder folder = SolutionTestsData.CreateFolder();
        Item item = SolutionTestsData.CreateItem();
        ProjectReference project = SolutionTestsData.CreateProject();
        Property property = SolutionTestsData.CreateProperty();

        // Act
        var subject = new Solution
        {
            Configurations = configurations,
            Files = [file],
            Folders = [folder],
            Items = [item],
            Projects = [project],
            Properties = [property],
        };

        // Assert
        _ = await Assert.That(subject.Configurations).IsEqualTo(configurations);
        _ = await Assert.That(subject.Files).IsEqualTo(new[] { file });
        _ = await Assert.That(subject.Folders).IsEqualTo(new[] { folder });
        _ = await Assert.That(subject.Items).IsEqualTo(new[] { item });
        _ = await Assert.That(subject.Projects).IsEqualTo(new[] { project });
        _ = await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        _ = await Assert.That(subject.IsUndefined).IsFalse();
    }
}