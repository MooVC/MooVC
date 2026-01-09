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
        subject.Configurations.ShouldBe(Configurations.Default);
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
        subject.Configurations.ShouldBe(configurations);
        subject.Files.ShouldBe(new[] { file });
        subject.Folders.ShouldBe(new[] { folder });
        subject.Items.ShouldBe(new[] { item });
        subject.Projects.ShouldBe(new[] { project });
        subject.Properties.ShouldBe(new[] { property });
        subject.IsUndefined.ShouldBeFalse();
    }
}