namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenTargetIsUndefined()
    {
        // Act
        var subject = new Target();

        // Assert
        subject.AfterTargets.ShouldBe(Snippet.Empty);
        subject.BeforeTargets.ShouldBe(Snippet.Empty);
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.DependsOnTargets.ShouldBe(Snippet.Empty);
        subject.Inputs.ShouldBe(Snippet.Empty);
        subject.KeepDuplicateOutputs.ShouldBeFalse();
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Identifier.Unnamed);
        subject.Outputs.ShouldBe(Snippet.Empty);
        subject.Returns.ShouldBe(Snippet.Empty);
        subject.Tasks.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        TargetTask task = TargetTestsData.CreateTask();

        // Act
        var subject = new Target
        {
            AfterTargets = Snippet.From(TargetTestsData.DefaultAfterTargets),
            BeforeTargets = Snippet.From(TargetTestsData.DefaultBeforeTargets),
            Condition = Snippet.From(TargetTestsData.DefaultCondition),
            DependsOnTargets = Snippet.From(TargetTestsData.DefaultDependsOnTargets),
            Inputs = Snippet.From(TargetTestsData.DefaultInputs),
            KeepDuplicateOutputs = true,
            Label = Snippet.From(TargetTestsData.DefaultLabel),
            Name = new Identifier(TargetTestsData.DefaultName),
            Outputs = Snippet.From(TargetTestsData.DefaultOutputs),
            Returns = Snippet.From(TargetTestsData.DefaultReturns),
            Tasks = [task],
        };

        // Assert
        subject.AfterTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultAfterTargets));
        subject.BeforeTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultBeforeTargets));
        subject.Condition.ShouldBe(Snippet.From(TargetTestsData.DefaultCondition));
        subject.DependsOnTargets.ShouldBe(Snippet.From(TargetTestsData.DefaultDependsOnTargets));
        subject.Inputs.ShouldBe(Snippet.From(TargetTestsData.DefaultInputs));
        subject.KeepDuplicateOutputs.ShouldBeTrue();
        subject.Label.ShouldBe(Snippet.From(TargetTestsData.DefaultLabel));
        subject.Name.ShouldBe(new Identifier(TargetTestsData.DefaultName));
        subject.Outputs.ShouldBe(Snippet.From(TargetTestsData.DefaultOutputs));
        subject.Returns.ShouldBe(Snippet.From(TargetTestsData.DefaultReturns));
        subject.Tasks.ShouldBe(new[] { task });
        subject.IsUndefined.ShouldBeFalse();
    }
}