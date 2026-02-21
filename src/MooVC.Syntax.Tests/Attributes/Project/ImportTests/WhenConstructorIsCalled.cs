namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenImportIsUndefined()
    {
        // Act
        var subject = new Import();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Project.ShouldBe(Snippet.Empty);
        subject.Sdk.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Import
        {
            Condition = ImportTestsData.DefaultCondition,
            Label = ImportTestsData.DefaultLabel,
            Project = ImportTestsData.DefaultProject,
            Sdk = ImportTestsData.DefaultSdk,
        };

        // Assert
        subject.Condition.ShouldBe(ImportTestsData.DefaultCondition);
        subject.Label.ShouldBe(ImportTestsData.DefaultLabel);
        subject.Project.ShouldBe(ImportTestsData.DefaultProject);
        subject.Sdk.ShouldBe(ImportTestsData.DefaultSdk);
        subject.IsUndefined.ShouldBeFalse();
    }
}