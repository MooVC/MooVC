namespace MooVC.Syntax.Concepts.SolutionTests;

using MooVC.Syntax.Attributes.Solution;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenSolutionIsUndefined()
    {
        // Act
        var subject = new Solution();

        // Assert
        subject.Configurations.ShouldBeEmpty();
        subject.Files.ShouldBeEmpty();
        subject.Folders.ShouldBeEmpty();
        subject.Items.ShouldBeEmpty();
        subject.Projects.ShouldBeEmpty();
        subject.Properties.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Configuration configuration = SolutionTestsData.CreateConfiguration();
        File file = SolutionTestsData.CreateFile();
        Folder folder = SolutionTestsData.CreateFolder();
        Item item = SolutionTestsData.CreateItem();
        ProjectReference project = SolutionTestsData.CreateProject();
        Property property = SolutionTestsData.CreateProperty();

        // Act
        var subject = new Solution
        {
            Configurations = [configuration],
            Files = [file],
            Folders = [folder],
            Items = [item],
            Projects = [project],
            Properties = [property],
        };

        // Assert
        subject.Configurations.ShouldBe(new[] { configuration });
        subject.Files.ShouldBe(new[] { file });
        subject.Folders.ShouldBe(new[] { folder });
        subject.Items.ShouldBe(new[] { item });
        subject.Projects.ShouldBe(new[] { project });
        subject.Properties.ShouldBe(new[] { property });
        subject.IsUndefined.ShouldBeFalse();
    }
}