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
        subject.Name.ShouldBe(Name.Unnamed);
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
            AfterTargets = TargetTestsData.DefaultAfterTargets,
            BeforeTargets = TargetTestsData.DefaultBeforeTargets,
            Condition = TargetTestsData.DefaultCondition,
            DependsOnTargets = TargetTestsData.DefaultDependsOnTargets,
            Inputs = TargetTestsData.DefaultInputs,
            KeepDuplicateOutputs = true,
            Label = TargetTestsData.DefaultLabel,
            Name = TargetTestsData.DefaultName,
            Outputs = TargetTestsData.DefaultOutputs,
            Returns = TargetTestsData.DefaultReturns,
            Tasks = [task],
        };

        // Assert
        subject.AfterTargets.ShouldBe(TargetTestsData.DefaultAfterTargets);
        subject.BeforeTargets.ShouldBe(TargetTestsData.DefaultBeforeTargets);
        subject.Condition.ShouldBe(TargetTestsData.DefaultCondition);
        subject.DependsOnTargets.ShouldBe(TargetTestsData.DefaultDependsOnTargets);
        subject.Inputs.ShouldBe(TargetTestsData.DefaultInputs);
        subject.KeepDuplicateOutputs.ShouldBeTrue();
        subject.Label.ShouldBe(TargetTestsData.DefaultLabel);
        subject.Name.ShouldBe(TargetTestsData.DefaultName);
        subject.Outputs.ShouldBe(TargetTestsData.DefaultOutputs);
        subject.Returns.ShouldBe(TargetTestsData.DefaultReturns);
        subject.Tasks.ShouldBe(new[] { task });
        subject.IsUndefined.ShouldBeFalse();
    }
}