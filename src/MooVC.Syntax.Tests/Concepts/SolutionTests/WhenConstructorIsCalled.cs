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
        await Assert.That(subject.Configurations).IsEqualTo(Configurations.Default);
        await Assert.That(subject.Files).IsEmpty();
        await Assert.That(subject.Folders).IsEmpty();
        await Assert.That(subject.Items).IsEmpty();
        await Assert.That(subject.Projects).IsEmpty();
        await Assert.That(subject.Properties).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
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
        await Assert.That(subject.Configurations).IsEqualTo(configurations);
        await Assert.That(subject.Files).IsEqualTo(new[] { file });
        await Assert.That(subject.Folders).IsEqualTo(new[] { folder });
        await Assert.That(subject.Items).IsEqualTo(new[] { item });
        await Assert.That(subject.Projects).IsEqualTo(new[] { project });
        await Assert.That(subject.Properties).IsEqualTo(new[] { property });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}