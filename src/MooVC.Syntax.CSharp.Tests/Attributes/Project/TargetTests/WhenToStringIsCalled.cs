namespace MooVC.Syntax.CSharp.Attributes.Project.TargetTests;

using System;
using System.Xml.Linq;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Target subject = Target.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        TargetTask task = TargetTestsData.CreateTask();
        Target subject = TargetTestsData.Create(task: task, keepDuplicateOutputs: true);

        var taskElement = new XElement(
            TargetTestsData.DefaultTaskName,
            new XAttribute(nameof(TargetTask.Condition), TargetTestsData.DefaultTaskCondition));

        var element = new XElement(
            nameof(Target),
            new XAttribute(nameof(Target.AfterTargets), TargetTestsData.DefaultAfterTargets),
            new XAttribute(nameof(Target.BeforeTargets), TargetTestsData.DefaultBeforeTargets),
            new XAttribute(nameof(Target.Condition), TargetTestsData.DefaultCondition),
            new XAttribute(nameof(Target.DependsOnTargets), TargetTestsData.DefaultDependsOnTargets),
            new XAttribute(nameof(Target.Inputs), TargetTestsData.DefaultInputs),
            new XAttribute(nameof(Target.KeepDuplicateOutputs), true.ToString().ToLowerInvariant()),
            new XAttribute(nameof(Target.Label), TargetTestsData.DefaultLabel),
            new XAttribute(nameof(Target.Name), TargetTestsData.DefaultName),
            new XAttribute(nameof(Target.Outputs), TargetTestsData.DefaultOutputs),
            new XAttribute(nameof(Target.Returns), TargetTestsData.DefaultReturns),
            taskElement);

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}