namespace MooVC.Syntax.Attributes.Project.TargetTests;

using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenDefaultsThenTargetIsUndefined()
    {
        // Act
        var subject = new Target();

        // Assert
        await Assert.That(subject.AfterTargets).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.BeforeTargets).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Condition).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.DependsOnTargets).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Inputs).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.KeepDuplicateOutputs).IsFalse();
        await Assert.That(subject.Label).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Outputs).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Returns).IsEqualTo(Snippet.Empty);
        await Assert.That(subject.Tasks).IsEmpty();
        await Assert.That(subject.IsUndefined).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
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
            Name = TargetTestsData.DefaultName,
            Outputs = Snippet.From(TargetTestsData.DefaultOutputs),
            Returns = Snippet.From(TargetTestsData.DefaultReturns),
            Tasks = [task],
        };

        // Assert
        await Assert.That(subject.AfterTargets).IsEqualTo(Snippet.From(TargetTestsData.DefaultAfterTargets));
        await Assert.That(subject.BeforeTargets).IsEqualTo(Snippet.From(TargetTestsData.DefaultBeforeTargets));
        await Assert.That(subject.Condition).IsEqualTo(Snippet.From(TargetTestsData.DefaultCondition));
        await Assert.That(subject.DependsOnTargets).IsEqualTo(Snippet.From(TargetTestsData.DefaultDependsOnTargets));
        await Assert.That(subject.Inputs).IsEqualTo(Snippet.From(TargetTestsData.DefaultInputs));
        await Assert.That(subject.KeepDuplicateOutputs).IsTrue();
        await Assert.That(subject.Label).IsEqualTo(Snippet.From(TargetTestsData.DefaultLabel));
        await Assert.That(subject.Name).IsEqualTo(new Name(TargetTestsData.DefaultName));
        await Assert.That(subject.Outputs).IsEqualTo(Snippet.From(TargetTestsData.DefaultOutputs));
        await Assert.That(subject.Returns).IsEqualTo(Snippet.From(TargetTestsData.DefaultReturns));
        await Assert.That(subject.Tasks).IsEqualTo(new[] { task });
        await Assert.That(subject.IsUndefined).IsFalse();
    }
}