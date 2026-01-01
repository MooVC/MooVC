namespace MooVC.Syntax.Attributes.Solution.ProjectTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        subject.Id.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Snippet.Empty);
        subject.Path.ShouldBe(Snippet.Empty);
        subject.Type.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Project
        {
            Id = Snippet.From(ProjectTestsData.DefaultId),
            Name = Snippet.From(ProjectTestsData.DefaultName),
            Path = Snippet.From(ProjectTestsData.DefaultPath),
            Type = Snippet.From(ProjectTestsData.DefaultType),
        };

        // Assert
        subject.Id.ShouldBe(Snippet.From(ProjectTestsData.DefaultId));
        subject.Name.ShouldBe(Snippet.From(ProjectTestsData.DefaultName));
        subject.Path.ShouldBe(Snippet.From(ProjectTestsData.DefaultPath));
        subject.Type.ShouldBe(Snippet.From(ProjectTestsData.DefaultType));
        subject.IsUndefined.ShouldBeFalse();
    }
}