namespace MooVC.Syntax.CSharp.Attributes.Project.ImportTests;

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
            Condition = Snippet.From(ImportTestsData.DefaultCondition),
            Label = Snippet.From(ImportTestsData.DefaultLabel),
            Project = Snippet.From(ImportTestsData.DefaultProject),
            Sdk = Snippet.From(ImportTestsData.DefaultSdk),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(ImportTestsData.DefaultCondition));
        subject.Label.ShouldBe(Snippet.From(ImportTestsData.DefaultLabel));
        subject.Project.ShouldBe(Snippet.From(ImportTestsData.DefaultProject));
        subject.Sdk.ShouldBe(Snippet.From(ImportTestsData.DefaultSdk));
        subject.IsUndefined.ShouldBeFalse();
    }
}